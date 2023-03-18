using DotNetProject.Application.Data.Interfaces;
using DotNetProject.Infrastructure.Persistence.Context;
using DotNetProject.Infrastructure.Persistence.Repositories;

using Neo4jClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<Neo4jContext>();

builder.Services.AddScoped<GremlinContext>();

builder.Services.AddScoped<IArticleRepository, ArticleRepository>();

// Neo4J
var client = new BoltGraphClient(new Uri("bolt://localhost:7687"), "neo4j", "Test@123");
client.ConnectAsync();

builder.Services.AddSingleton<IGraphClient>(client);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();