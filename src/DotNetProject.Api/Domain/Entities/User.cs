namespace DotNetProject.Api.Domain.Entities;

public class User
{
    public string Id { get; set; }

    public string Name { get; private set; }

    public User(string id, string name)
    {
        Id = id;
        Name = name;
    }
}
