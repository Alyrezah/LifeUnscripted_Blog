using LifeUnscripted_Blog.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifeUnscripted_Blog.Web.Areas.Administrator.Pages.ManageArticleCategories
{
    public class EditModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        [BindProperty]
        public EditArticleCategoryDto ArticleCategory { get; set; }

        public void OnGet(long id)
        {
            ArticleCategory = _articleCategoryApplication.GetForEdit(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "An error occurred during the edit operation. Please enter the information correctly.");
                return Page();
            }
            var result = _articleCategoryApplication.Edit(ArticleCategory);
            if (result == false)
            {
                ModelState.AddModelError("", "An error occurred during the edit operation. Please enter the information correctly.");
                return Page();
            }
            return RedirectToPage("Index");
        }
    }
}
