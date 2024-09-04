namespace LifeUnscripted_Blog.Application.Contracts.Comment
{
    public class AddCommentDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public long ArticleId { get; set; }
    }
}
