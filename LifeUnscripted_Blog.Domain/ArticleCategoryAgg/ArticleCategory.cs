using LifeUnscripted_Blog.Domain.ArticleAgg;
using LifeUnscripted_Blog.Domain.Common;

namespace LifeUnscripted_Blog.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : BaseEntity
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string MetaTag { get; private set; }
        public string MetaDescription { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public bool IsDeleted { get; private set; }
        public virtual List<Article> Articles { get; private set; }

        protected ArticleCategory()
        {
            
        }

        public ArticleCategory(string title, string slug, string metaTag, string metaDescription)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Slug = slug ?? throw new ArgumentNullException(nameof(slug));
            MetaTag = metaTag ?? throw new ArgumentNullException(nameof(metaTag));
            MetaDescription = metaDescription ?? throw new ArgumentNullException(nameof(metaDescription));
            UpdateDate = DateTime.Now;
            IsDeleted = false;
            Articles = new List<Article>();
        }

        public void Edit(string title, string slug, string metaTag, string metaDescription)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Slug = slug ?? throw new ArgumentNullException(nameof(slug));
            MetaTag = metaTag ?? throw new ArgumentNullException(nameof(metaTag));
            MetaDescription = metaDescription ?? throw new ArgumentNullException(nameof(metaDescription));
            UpdateDate = DateTime.Now;
        }

        public void ChangeIsDeleted()
        {
            IsDeleted = !IsDeleted;
        }
    }
}
