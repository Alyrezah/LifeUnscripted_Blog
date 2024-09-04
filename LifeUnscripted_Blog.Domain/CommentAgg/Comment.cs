using LifeUnscripted_Blog.Domain.ArticleAgg;
using LifeUnscripted_Blog.Domain.Common;

namespace LifeUnscripted_Blog.Domain.CommentAgg
{
    public class Comment : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirm { get; private set; }
        public bool IsDeleted { get; private set; }
        public long ArticleId { get; private set; }
        public virtual Article Article { get; private set; }

        protected Comment()
        {
            
        }

        public Comment(string name, string email, string message, long articleId)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Message = message ?? throw new ArgumentNullException(nameof(message));
            ArticleId = articleId;
            IsConfirm = false;
        }

        public void Confirm()
        {
            IsConfirm = true;
        }

        public void CheangeIsDeleted()
        {
            IsDeleted = !IsDeleted;
        }
    }
}
