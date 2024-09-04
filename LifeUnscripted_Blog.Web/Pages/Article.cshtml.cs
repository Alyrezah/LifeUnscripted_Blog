using LifeUnscripted_Blog.Application.Contracts.Comment;
using LifeUnscripted_Blog.Infra.Query.Articles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifeUnscripted_Blog.Web.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;
        public ArticleModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }

        public ArticleQueryModel Article { get; set; }

        public IActionResult OnGet(string slug)
        {
            Article = _articleQuery.GetSingleArticle(slug);

            if (Article == null)
            {
                return NotFound();
            }

            return Page();
        }

        [BindProperty]
        public AddCommentDto Comment { get; set; }

        public IActionResult OnPostAddComment()
        {
            var result = _commentApplication.AddComment(Comment);
            if (result.Item1 == false)
            {
                Article = _articleQuery.GetSingleArticle(result.Item2);

                if (Article == null)
                {
                    return NotFound();
                }

                return Page();
            }

            return RedirectToPage("Article", result.Item2);
        }
    }
}
