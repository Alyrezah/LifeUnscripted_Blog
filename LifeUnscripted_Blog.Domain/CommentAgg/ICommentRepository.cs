using LifeUnscripted_Blog.Application.Contracts.Comment;
using LifeUnscripted_Blog.Domain.Common;

namespace LifeUnscripted_Blog.Domain.CommentAgg
{
    public interface ICommentRepository : IGenericRepository<long, Comment>
    {
        List<CommentDto> GetList();
    }
}
