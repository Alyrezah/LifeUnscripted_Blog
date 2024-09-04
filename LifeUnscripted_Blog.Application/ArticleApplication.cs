using LifeUnscripted_Blog.Application.Contracts.Article;
using LifeUnscripted_Blog.Common.Utilities;
using LifeUnscripted_Blog.Domain.ArticleAgg;

namespace LifeUnscripted_Blog.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public bool ChangeIsDeleted(long id)
        {
            var article = _articleRepository.GetBy(id);
            if (article == null)
            {
                return false;
            }

            article.ChangeIsDeleted();
            _articleRepository.Save();
            return true;
        }

        public bool Create(CreateArticleDto command)
        {
            var slug = command.Slug.FixSlug();
            var article = new Article(command.Title, slug, command.MetaTag, command.ShortDescription, command.MetaDescription,
                command.Description, command.ImageName, command.CategoryId, command.AuthorId);
            _articleRepository.Create(article);
            _articleRepository.Save();

            return true;
        }

        public bool Edit(EditArticleDto command)
        {
            var article = _articleRepository.GetBy(command.Id);

            if (article == null || article.Id != command.Id)
            {
                return false;
            }

            var slug = command.Slug.FixSlug();
            article.Edit(command.Title, slug, command.MetaTag, command.ShortDescription,
                command.MetaDescription, command.Description, command.ImageName, command.CategoryId);
            _articleRepository.Save();
            return true;
        }

        public List<ArticleDto> GetAll()
        {
            return _articleRepository.GetList();
        }

        public EditArticleDto GetForEdit(long id)
        {
            return _articleRepository.GetForEdit(id);
        }
    }
}
