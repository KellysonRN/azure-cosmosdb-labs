using Neo4j.Driver;

namespace DotNetProject.Infrastructure.Persistence.Context;

public class Neo4jContext : IDisposable
{
    private readonly string _uri = "bolt://localhost:7687";

    private string _user = "neo4j";

    private string _password = "Test@123";

    private bool _disposed;

    private readonly IDriver _driver;

    ~Neo4jContext() => Dispose(false);

    public Neo4jContext()
    {
        _driver = GraphDatabase.Driver(_uri, AuthTokens.Basic(_user, _password));
    }

    public IAsyncSession GetAsyncSession()
    {
        IAsyncSession session = _driver.AsyncSession(o => o.WithDatabase("neo4j"));

        return session;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {            
            _driver?.Dispose();
        }

        _disposed = true;
    }
}
