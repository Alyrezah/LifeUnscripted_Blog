namespace LifeUnscripted_Blog.Infra.Query.ArticleCategories
{
    public interface IArticleCategoriesQuery
    {
        List<ArticleCategoryQueryModel> GetArticleCategoriesForBlogSideBar();
    }
}
