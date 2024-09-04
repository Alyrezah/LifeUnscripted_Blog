using LifeUnscripted_Blog.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifeUnscripted_Blog.Web.Areas.Administrator.Pages.ManageArticleCategories
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public List<ArticleCategoryDto> ArticleCategories { get; set; }

        public void OnGet()
        {
            this.ArticleCategories = _articleCategoryApplication.GetAll();
        }

        public IActionResult OnGetChangeIsDeleted(long id)
        {
            var result = _articleCategoryApplication.ChangeIsDeleted(id);
            if (result == false)
            {
                return BadRequest();
            }
            return RedirectToPage("Index");
        }
    }
}
