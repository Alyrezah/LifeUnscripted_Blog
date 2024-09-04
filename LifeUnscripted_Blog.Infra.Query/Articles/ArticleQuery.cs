using LifeUnscripted_Blog.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;

namespace LifeUnscripted_Blog.Infra.Query.Articles
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly LifeUnscriptedDbContext _context;
        public ArticleQuery(LifeUnscriptedDbContext context)
        {
            _context = context;
        }

        public List<ArticleQueryModel> GetArticlesInBlog(SearchArticlesQuryModel search)
        {
            var query = _context.Articles
                .Include(x => x.ArticleCategory)
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .Where(x => x.IsDeleted == false && x.ArticleCategory.IsDeleted == false)
                .OrderByDescending(x => x.Id)
                .Select(x => new ArticleQueryModel()
                {
                    Author = x.Author.FullName,
                    Category = x.ArticleCategory.Title,
                    CommentCount = x.Comments.Where(x => x.IsConfirm && x.IsDeleted == false).Count(),
                    Title = x.Title,
                    CreationDate = x.CreationDate.ToShortDateString(),
                    ImageName = x.ImageName,
                    ShortDescription = x.ShortDescription,
                    Slug = x.Slug,
                    CategorySlug = x.ArticleCategory.Slug
                }).AsQueryable();

            if (!string.IsNullOrEmpty(search.Title))
            {
                query = query.Where(x => x.Title.Contains(search.Title));
            }

            if (!string.IsNullOrEmpty(search.Category))
            {
                query = query.Where(x => x.CategorySlug == search.Category);
            }

            return query.ToList();
        }

        public List<ArticleQueryModel> GetLatestArticles()
        {
            return _context.Articles
                .Include(x => x.Comments)
                .Where(x => x.IsDeleted == false && x.ArticleCategory.IsDeleted == false)
                .OrderByDescending(x => x.Id)
                .Take(3)
                .Select(x => new ArticleQueryModel()
                {
                    Title = x.Title,
                    ImageName = x.ImageName,
                    CommentCount = x.Comments.Where(x => x.IsConfirm && x.IsDeleted == false).Count()
                }).ToList();

        }

        public List<ArticleQueryModel> GetLatestArticlesInHomePage()
        {
            return _context.Articles
                .Where(x => x.IsDeleted == false && x.ArticleCategory.IsDeleted == false)
                .OrderByDescending(x => x.Id)
                .Take(3)
                .Select(x => new ArticleQueryModel()
                {
                    Category = x.ArticleCategory.Title,
                    CategorySlug = x.ArticleCategory.Slug,
                    Title = x.Title,
                    ImageName = x.ImageName,
                    ShortDescription = x.ShortDescription,
                    Slug = x.Slug,
                    CreationDate = x.CreationDate.ToShortDateString(),
                }).ToList();
        }

        public ArticleQueryModel GetSingleArticle(string slug)
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Where(x => x.IsDeleted == false && x.Slug == slug && x.ArticleCategory.IsDeleted == false)
                .Select(x => new ArticleQueryModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageName = x.ImageName,
                    Slug = x.Slug,
                    Author = x.Author.FullName,
                    Category = x.ArticleCategory.Title,
                    CategorySlug = x.ArticleCategory.Slug,
                    CommentCount = x.Comments.Where(x => x.IsConfirm && x.IsDeleted == false).Count(),
                    CreationDate = x.CreationDate.ToShortDateString(),
                    Description = x.Description,
                    MetaDescription = x.MetaDescription,
                    MetaTag = x.MetaTag,
                    ShortDescription = x.ShortDescription,
                    ArticleComments = x.Comments
                    .Where(x => x.IsConfirm && x.IsDeleted == false)
                    .Select(c => new ArticleCommentQureyModel()
                    {
                        CreationDate = c.CreationDate.ToShortDateString(),
                        Message = c.Message,
                        Name = c.Name
                    })
                    .ToList()
                }).SingleOrDefault();
        }
    }
}
