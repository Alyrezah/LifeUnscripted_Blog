using LifeUnscripted_Blog.Domain.ArticleCategoryAgg;
using LifeUnscripted_Blog.Domain.CommentAgg;
using LifeUnscripted_Blog.Domain.Common;
using LifeUnscripted_Blog.Domain.UserAgg;

namespace LifeUnscripted_Blog.Domain.ArticleAgg
{
    public class Article : BaseEntity
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string MetaTag { get; private set; }
        public string ShortDescription { get; private set; }
        public string MetaDescription { get; private set; }
        public string Description { get; private set; }
        public string ImageName { get; set; }
        public DateTime UpdateDate { get; private set; }
        public bool IsDeleted { get; private set; }
        public long CategoryId { get; private set; }
        public virtual ArticleCategory ArticleCategory { get; private set; }
        public string AuthorId { get; private set; }
        public virtual User Author { get; private set; }
        public virtual List<Comment> Comments { get; set; }

        protected Article()
        {
            
        }

        public Article(string title, string slug, string metaTag, string shortDescription, 
            string metaDescription, string description, string imageName, long categoryId, string authorId)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Slug = slug ?? throw new ArgumentNullException(nameof(slug));
            MetaTag = metaTag ?? throw new ArgumentNullException(nameof(metaTag));
            ShortDescription = shortDescription ?? throw new ArgumentNullException(nameof(shortDescription));
            MetaDescription = metaDescription ?? throw new ArgumentNullException(nameof(metaDescription));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ImageName = imageName ?? throw new ArgumentNullException(nameof(imageName));
            CategoryId = categoryId;
            AuthorId = authorId ?? throw new ArgumentNullException(nameof(authorId));
            IsDeleted = false;
            UpdateDate = DateTime.Now;
            Comments = new List<Comment>();
        }

        public void Edit(string title, string slug, string metaTag, string shortDescription,
            string metaDescription, string description, string imageName, long categoryId)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Slug = slug ?? throw new ArgumentNullException(nameof(slug));
            MetaTag = metaTag ?? throw new ArgumentNullException(nameof(metaTag));
            ShortDescription = shortDescription ?? throw new ArgumentNullException(nameof(shortDescription));
            MetaDescription = metaDescription ?? throw new ArgumentNullException(nameof(metaDescription));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            if (!string.IsNullOrEmpty(imageName))
            {
                ImageName = imageName;
            }
            CategoryId = categoryId;
            UpdateDate = DateTime.Now;
        }

        public void ChangeIsDeleted()
        {
            IsDeleted = !IsDeleted;
        }
    }
}
