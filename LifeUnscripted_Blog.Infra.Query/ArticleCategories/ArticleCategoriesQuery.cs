using LifeUnscripted_Blog.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;

namespace LifeUnscripted_Blog.Infra.Query.ArticleCategories
{
    public class ArticleCategoriesQuery : IArticleCategoriesQuery
    {
        private readonly LifeUnscriptedDbContext _context;
        public ArticleCategoriesQuery(LifeUnscriptedDbContext context)
        {
            _context = context;
        }

        public List<ArticleCategoryQueryModel> GetArticleCategoriesForBlogSideBar()
        {
            return _context.ArticleCategories
                .Where(x=>x.IsDeleted == false)
                .OrderByDescending(x=>x.Id)
                .Include(x=>x.Articles)
                .Select(x=> new ArticleCategoryQueryModel()
                {
                    ArticlesCount = x.Articles.Count,
                    Slug = x.Slug,
                    Title = x.Title,
                }).ToList();
        }
    }
}
