using LifeUnscripted_Blog.Application.Contracts.Article;
using LifeUnscripted_Blog.Domain.Common;

namespace LifeUnscripted_Blog.Domain.ArticleAgg
{
    public interface IArticleRepository : IGenericRepository<long, Article>
    {
        List<ArticleDto> GetList();
        EditArticleDto GetForEdit(long id);
        string ReturnArticleSlugBy(long id);
    }
}
