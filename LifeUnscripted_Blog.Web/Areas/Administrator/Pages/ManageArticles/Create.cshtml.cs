using LifeUnscripted_Blog.Application.Contracts.Article;
using LifeUnscripted_Blog.Application.Contracts.ArticleCategory;
using LifeUnscripted_Blog.Web.FileUploader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LifeUnscripted_Blog.Web.Areas.Administrator.Pages.ManageArticles
{
    public class CreateModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IFileUploader _fileUploader;
        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication, IFileUploader fileUploader)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
            _fileUploader = fileUploader;
        }

        [BindProperty]
        public CreateArticleDto Article { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public SelectList SeleteCategoryItems { get; set; }

        public void OnGet()
        {
            SeleteCategoryItems = new SelectList(_articleCategoryApplication.GetAll(), "Id", "Title");
        }

        public IActionResult OnPost()
        {
            Article.AuthorId = "A081407B-FD76-429B-ACA5-1A1158F6B91E";
            Article.ImageName = _fileUploader.Upload(Image, "Articles");

            if (!ModelState.IsValid)
            {
                SeleteCategoryItems = new SelectList(_articleCategoryApplication.GetAll(), "Id", "Title");
                return Page();
            }

            var result = _articleApplication.Create(Article);

            if (result == false)
            {
                SeleteCategoryItems = new SelectList(_articleCategoryApplication.GetAll(), "Id", "Title");
                ModelState.AddModelError("", "An error occurred during the add operation. Please enter the information correctly.");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
