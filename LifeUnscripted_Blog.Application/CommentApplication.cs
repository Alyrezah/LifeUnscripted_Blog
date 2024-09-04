using LifeUnscripted_Blog.Application.Contracts.Comment;
using LifeUnscripted_Blog.Domain.ArticleAgg;
using LifeUnscripted_Blog.Domain.CommentAgg;

namespace LifeUnscripted_Blog.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IArticleRepository _articleRepository;
        public CommentApplication(ICommentRepository commentRepository, IArticleRepository articleRepository)
        {
            _commentRepository = commentRepository;
            _articleRepository = articleRepository;
        }

        public Tuple<bool, string> AddComment(AddCommentDto commnad)
        {
            var comment = new Comment(commnad.Name, commnad.Email, commnad.Message, commnad.ArticleId);
            _commentRepository.Create(comment);
            _commentRepository.Save();
            return Tuple.Create(true, _articleRepository.ReturnArticleSlugBy(commnad.ArticleId));
        }

        public bool CheangeIsDeleted(long id)
        {
            var comment = _commentRepository.GetBy(id);
            if (comment == null)
            {
                return false;
            }

            comment.CheangeIsDeleted();
            _commentRepository.Save();
            return true;
        }

        public bool Confirm(long id)
        {
            var comment = _commentRepository.GetBy(id);
            if (comment == null)
            {
                return false;
            }

            comment.Confirm();
            _commentRepository.Save();
            return true;
        }

        public List<CommentDto> GetAll()
        {
            return _commentRepository.GetList();
        }
    }
}
