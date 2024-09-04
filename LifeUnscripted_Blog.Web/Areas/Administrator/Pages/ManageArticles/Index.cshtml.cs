using LifeUnscripted_Blog.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifeUnscripted_Blog.Web.Areas.Administrator.Pages.ManageArticles
{
    public class IndexModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        public IndexModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public List<ArticleDto> Articles { get; set; }

        public void OnGet()
        {
            Articles = _articleApplication.GetAll();
        }

        public IActionResult OnGetChangeIsDeleted(long id)
        {
            var result = _articleApplication.ChangeIsDeleted(id);
            if (result == false)
            {
                return BadRequest();
            }
            return RedirectToPage("Index");
        }
    }
}
