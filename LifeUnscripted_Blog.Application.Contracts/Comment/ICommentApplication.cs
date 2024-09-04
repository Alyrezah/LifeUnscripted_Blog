namespace LifeUnscripted_Blog.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        List<CommentDto> GetAll();
        Tuple<bool,string> AddComment(AddCommentDto comment);
        bool Confirm(long id);
        bool CheangeIsDeleted(long id);
    }
}
