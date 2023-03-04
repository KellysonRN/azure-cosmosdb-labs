using DotNetProject.Api.Domain.Entities;
using DotNetProject.Application.Data.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace DotNetProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;

        private readonly IArticleRepository _repository;

        public ArticleController(ILogger<ArticleController> logger, IArticleRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var articles = await _repository.GetAll();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await _repository.Retrieve(id);

            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Article article)
        {
            await _repository.Create(article);

            return Ok();
        }

        [HttpPost("act")]
        public async Task<IActionResult> CreateRelationships([FromQuery] int id1, int id2)
        {
            Article a = new Article()
            {
                Id = id1,
                AuthorName = "KellysonRN",
                Title = "Parte 1",
                Subject = "Graph Database"
            };
            Article b = new Article(id2, "Parte 2", "Graph Database", "KellysonRN");

            await _repository.CreateRelationships(a, b);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Article model)
        {
            var entity = new Article(id, model.Title, model.Subject, model.AuthorName);

            await _repository.Update(entity);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);

            return Ok();
        }
    }
}