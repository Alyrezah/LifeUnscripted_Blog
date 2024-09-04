using LifeUnscripted_Blog.Application.Contracts.Article;
using LifeUnscripted_Blog.Application.Contracts.ArticleCategory;
using LifeUnscripted_Blog.Web.FileUploader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LifeUnscripted_Blog.Web.Areas.Administrator.Pages.ManageArticles
{
    public class EditModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IFileUploader _fileUploader;
        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication, IFileUploader fileUploader)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
            _fileUploader = fileUploader;
        }

        [BindProperty]
        public EditArticleDto Article { get; set; }

        [BindProperty]
        public IFormFile? Image { get; set; }

        public SelectList SeleteCategoryItems { get; set; }

        public void OnGet(long id)
        {
            SeleteCategoryItems = new SelectList(_articleCategoryApplication.GetAll(), "Id", "Title");
            Article = _articleApplication.GetForEdit(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                SeleteCategoryItems = new SelectList(_articleCategoryApplication.GetAll(), "Id", "Title");
                ModelState.AddModelError("", "An error occurred during the edit operation. Please enter the information correctly.");
                return Page();
            }

            if (Image != null && Image.Length > 0)
            {
                var imageName = _fileUploader.Upload(Image, "Articles");
                Article.ImageName = imageName;
            }

            var result = _articleApplication.Edit(Article);
            if (result == false)
            {
                SeleteCategoryItems = new SelectList(_articleCategoryApplication.GetAll(), "Id", "Title");
                ModelState.AddModelError("", "An error occurred during the edit operation. Please enter the information correctly.");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
