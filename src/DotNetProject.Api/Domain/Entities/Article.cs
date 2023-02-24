namespace DotNetProject.Api.Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subject { get; set; }

        public string AuthorName { get; set; }

        public static Article Empty { get { return new Article(0, string.Empty, string.Empty, string.Empty); } }

        public Article()
        { }

        public Article(int id, string title, string subject, string authorName)
        {
            Id = id;
            Title = title;
            Subject = subject;
            AuthorName = authorName;
        }
    }
}