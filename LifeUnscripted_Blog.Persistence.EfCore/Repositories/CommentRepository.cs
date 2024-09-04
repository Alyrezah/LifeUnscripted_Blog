using LifeUnscripted_Blog.Application.Contracts.Comment;
using LifeUnscripted_Blog.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace LifeUnscripted_Blog.Persistence.EfCore.Repositories
{
    public class CommentRepository : GenericRepository<long, Comment>, ICommentRepository
    {
        private readonly LifeUnscriptedDbContext _context;
        public CommentRepository(LifeUnscriptedDbContext context) : base(context)
        {
            _context = context;
        }

        public List<CommentDto> GetList()
        {
            return _context.Comments
                .OrderByDescending(x => x.Id)
                .Include(x=>x.Article)
                .Select(x=> new CommentDto()
                {
                    Article = x.Article.Title,
                    CreationDate = x.CreationDate.ToShortDateString(),
                    Email = x.Email,
                    Id = x.Id,
                    IsConfirm = x.IsConfirm,
                    Message = x.Message,
                    Name = x.Name,
                    IsDeleted = x.IsDeleted,
                }).ToList();
        }
    }
}
