using LifeUnscripted_Blog.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifeUnscripted_Blog.Web.Areas.Administrator.Pages.ManageComments
{
    public class IndexModel : PageModel
    {
        private readonly ICommentApplication _commentApplication;
        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public List<CommentDto> Comments { get; set; }
        public void OnGet()
        {
            Comments = _commentApplication.GetAll();
        }


        public IActionResult OnGetConfirm(long id)
        {
            var result = _commentApplication.Confirm(id);
            if (result == false)
            {
                return BadRequest();
            }

            return RedirectToPage("Index");
        }

        public IActionResult OnGetChangeIsDeleted(long id)
        {
            var result = _commentApplication.CheangeIsDeleted(id);
            if (result == false)
            {
                return BadRequest();
            }
            return RedirectToPage("Index");
        }
    }
}
