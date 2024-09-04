namespace LifeUnscripted_Blog.Application.Contracts.Article
{
    public class EditArticleDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string ShortDescription { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public string? ImageName { get; set; }
        public long CategoryId { get; set; }
    }
}
