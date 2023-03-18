using DotNetProject.Infrastructure.Persistence.Context;

using Gremlin.Net.Driver;
using Gremlin.Net.Driver.Messages;

using Microsoft.AspNetCore.Mvc;

namespace DotNetProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GremlinController : ControllerBase
    {
        private readonly GremlinContext _g;

        public GremlinController(GremlinContext g)
        {
            _g = g;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            var query =  @"g.V()
                           .hasLabel('name')
                           .has('value', 'Kellyson')
                           .count()";

            var request = RequestMessage.Build(Tokens.OpsEval)
                                        .AddArgument(Tokens.ArgsGremlin, query)
                                        .AddArgument(Tokens.ArgsEvalTimeout, 500)
                                        .Create();

            var result = await _g.GremlinClient.SubmitAsync<string>(request);


            return result.AsEnumerable<string>();

        }
    }
}