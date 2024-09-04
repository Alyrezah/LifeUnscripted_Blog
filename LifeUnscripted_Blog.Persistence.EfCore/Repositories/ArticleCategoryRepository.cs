using LifeUnscripted_Blog.Domain.ArticleCategoryAgg;

namespace LifeUnscripted_Blog.Persistence.EfCore.Repositories
{
    public class ArticleCategoryRepository : GenericRepository<long,ArticleCategory>, IArticleCategoryRepository
    {
        private readonly LifeUnscriptedDbContext _context;
        public ArticleCategoryRepository(LifeUnscriptedDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
