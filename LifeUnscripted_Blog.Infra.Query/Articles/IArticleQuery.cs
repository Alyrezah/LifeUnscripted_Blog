namespace LifeUnscripted_Blog.Infra.Query.Articles
{
    public interface IArticleQuery
    {
        List<ArticleQueryModel> GetArticlesInBlog(SearchArticlesQuryModel search);
        List<ArticleQueryModel> GetLatestArticles();
        List<ArticleQueryModel> GetLatestArticlesInHomePage();
        ArticleQueryModel GetSingleArticle(string slug);
    }
}
