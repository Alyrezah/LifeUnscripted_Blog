using LifeUnscripted_Blog.Infra.Query.Articles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifeUnscripted_Blog.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IArticleQuery _articleQuery;
        public IndexModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public List<ArticleQueryModel> Articles { get; set; }

        public void OnGet()
        {
            Articles = _articleQuery.GetLatestArticlesInHomePage();
        }
    }
}
