using DotNetProject.Api.Domain.Entities;

namespace DotNetProject.Application.Data.Interfaces;

public interface IArticleRepository
{
    Task<bool> Create(Article obj);
    Task<Article> Retrieve(int key);
    Task<IEnumerable<Article>> GetAll();
    Task<bool> Update(Article obj);
    Task<bool> Delete(int key);
}
