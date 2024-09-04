using LifeUnscripted_Blog.Application.Contracts.Article;
using LifeUnscripted_Blog.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace LifeUnscripted_Blog.Persistence.EfCore.Repositories
{
    public class ArticleRepository : GenericRepository<long, Article>, IArticleRepository
    {
        private readonly LifeUnscriptedDbContext _context;
        public ArticleRepository(LifeUnscriptedDbContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleDto> GetList()
        {
            return _context.Articles
                .OrderByDescending(x => x.Id)
                .Include(x => x.Author)
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleDto()
                {
                    Id = x.Id,
                    Author = x.Author.FullName,
                    Category = x.ArticleCategory.Title,
                    Title = x.Title,
                    CreationDate = x.CreationDate.ToShortDateString(),
                    IsDeleted = x.IsDeleted,
                }).ToList();
        }

        public EditArticleDto GetForEdit(long id)
        {
            return _context.Articles.Select(x => new EditArticleDto()
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Description = x.Description,
                ImageName = x.ImageName,
                MetaDescription = x.MetaDescription,
                MetaTag = x.MetaTag,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                Title = x.Title
            }).First(x => x.Id == id);
        }

        public string ReturnArticleSlugBy(long id)
        {
            return _context.Articles.Where(x => x.Id == id)
                .Select(x => x.Slug).FirstOrDefault();
        }
    }
}
