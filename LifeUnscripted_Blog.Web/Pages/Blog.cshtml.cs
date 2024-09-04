using LifeUnscripted_Blog.Infra.Query.ArticleCategories;
using LifeUnscripted_Blog.Infra.Query.Articles;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifeUnscripted_Blog.Web.Pages
{
    public class BlogModel : PageModel
    {
        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoriesQuery _articleCategoriesQuery;
        public BlogModel(IArticleQuery articleQuery, IArticleCategoriesQuery articleCategoriesQuery)
        {
            _articleQuery = articleQuery;
            _articleCategoriesQuery = articleCategoriesQuery;
        }

        public List<ArticleQueryModel> Articles { get; set; }
        public List<ArticleQueryModel> LatestArticles { get; set; }
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
        public SearchArticlesQuryModel Search { get; set; }

        public void OnGet(SearchArticlesQuryModel search)
        {
            Search = search;
            Articles = _articleQuery.GetArticlesInBlog(search);
            LatestArticles = _articleQuery.GetLatestArticles();
            ArticleCategories = _articleCategoriesQuery.GetArticleCategoriesForBlogSideBar();
        }
    }
}
