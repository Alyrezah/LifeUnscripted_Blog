namespace LifeUnscripted_Blog.Infra.Query.Articles
{
    public class ArticleQueryModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string ShortDescription { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public string Category { get; set; }
        public string CategorySlug { get; set; }
        public string Author { get; set; }
        public string CreationDate { get; set; }
        public int CommentCount { get; set; }
        public List<ArticleCommentQureyModel> ArticleComments { get; set; }
    }
}
