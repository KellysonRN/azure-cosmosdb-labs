using System.Net.WebSockets;

using Gremlin.Net.Driver;
using Gremlin.Net.Structure.IO.GraphSON;

namespace DotNetProject.Infrastructure.Persistence.Context;

public class GremlinContext : IDisposable
{
    private string Host = string.Empty;

    private string PrimaryKey = string.Empty;

    private string Database = string.Empty;

    private string Container = string.Empty;

    private bool EnableSSL = true;

    private int Port = 443;

    private GremlinClient _gremlinClient;

    public GremlinClient GremlinClient
    {
        get { return _gremlinClient; }
        set { _gremlinClient = value; }
    }

    public GremlinContext(IConfiguration config)
    {
        Host = $"{config.GetValue<string>("Database:Host")}";
        Database = $"{config.GetValue<string>("Database:Name")}";
        PrimaryKey = $"{config.GetValue<string>("PrimaryKey")}";
        
        string containerLink = $"/dbs/{Database}/colls/{Container}";

        var gremlinServer = new GremlinServer(
               hostname: Host,
               port: Port,
               enableSsl: EnableSSL,
               username: containerLink,
               password: PrimaryKey
           );

        ConnectionPoolSettings connectionPoolSettings = new ConnectionPoolSettings()
        {
            MaxInProcessPerConnection = 10,
            PoolSize = 30,
            ReconnectionAttempts = 3,
            ReconnectionBaseDelay = TimeSpan.FromMilliseconds(500)
        };

        var webSocketConfiguration = new Action<ClientWebSocketOptions>(options =>
        {
            options.KeepAliveInterval = TimeSpan.FromSeconds(10);
        });

        var serializer = new GraphSON2MessageSerializer(new GraphSON2Reader(), new GraphSON2Writer());

        _gremlinClient = new GremlinClient(gremlinServer,
                                            serializer,
                                            connectionPoolSettings,
                                            webSocketConfiguration);

        _gremlinClient = new GremlinClient(
                gremlinServer: gremlinServer,
                connectionPoolSettings: connectionPoolSettings);
    }

    public void Dispose()
    {
        if (_gremlinClient is not null)
            _gremlinClient.Dispose();
    }
}
