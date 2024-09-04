using LifeUnscripted_Blog.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifeUnscripted_Blog.Web.Areas.Administrator.Pages.ManageArticleCategories
{
    public class CreateModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public CreateArticleCategoryDto ArticleCategory { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _articleCategoryApplication.Create(ArticleCategory);
            if (result == false)
            {
                ModelState.AddModelError("", "An error occurred during the add operation. Please enter the information correctly.");
                return Page();
            }
            return RedirectToPage("Index");
        }
    }
}
