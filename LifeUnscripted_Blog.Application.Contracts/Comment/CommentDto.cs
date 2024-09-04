using LifeUnscripted_Blog.Application.Contracts.Common;

namespace LifeUnscripted_Blog.Application.Contracts.Comment
{
    public class CommentDto : BaseApplicationDto
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public string Article { get; set; }
        public bool IsConfirm { get; set; }
        public string Email { get; set; }
    }
}
