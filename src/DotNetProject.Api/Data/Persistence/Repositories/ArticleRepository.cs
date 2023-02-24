using DotNetProject.Api.Domain.Entities;
using DotNetProject.Application.Data.Interfaces;

using Neo4jClient;

namespace DotNetProject.Infrastructure.Persistence.Repositories;

public class ArticleRepository : IArticleRepository
{
    private readonly IGraphClient _client;

    public ArticleRepository(IGraphClient client)
    {
        _client = client;
    }

    public async Task<bool> Create(Article obj)
    {
        try
        {
            await _client.Cypher.Create("(a:Article $article)")
                                 .WithParam("article", obj)
                                 .ExecuteWithoutResultsAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> Delete(int key)
    {
        try
        {
            await _client.Cypher.Match("(a:Article)")
                               .Where((Article a) => a.Id == key)
                               .Delete("a")
                               .ExecuteWithoutResultsAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<IEnumerable<Article>> GetAll()
    {
        var articles = await _client.Cypher.Match("(a: Article)")
                                                .Return(a => a.As<Article>()).ResultsAsync;

        return articles;
    }

    public async Task<Article> Retrieve(int key)
    {
        var article = await _client.Cypher.Match("(a:Article)")
                                                  .Where((Article a) => a.Id == key)
                                                  .Return(a => a.As<Article>()).ResultsAsync;

        return article.LastOrDefault();
    }

    public async Task<bool> Update(Article obj)
    {
        try
        {
            await _client.Cypher.Match("(a:Article)")
                                .Where((Article a) => a.Id.Equals(obj.Id))
                                .Set("a = $article")
                                .WithParam("article", obj)
                                .ExecuteWithoutResultsAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
