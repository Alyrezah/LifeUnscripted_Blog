using LifeUnscripted_Blog.Application.Contracts.ArticleCategory;
using LifeUnscripted_Blog.Common.Utilities;
using LifeUnscripted_Blog.Domain.ArticleCategoryAgg;

namespace LifeUnscripted_Blog.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public bool ChangeIsDeleted(long id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            if (articleCategory == null)
            {
                return false;
            }

            articleCategory.ChangeIsDeleted();
            _articleCategoryRepository.Save();
            return true;
        }

        public bool Create(CreateArticleCategoryDto command)
        {
            var slug = command.Slug.FixSlug();
            var articleCategory = new ArticleCategory(command.Title, slug, command.MetaTag,
                command.MetaDescription);

            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.Save();

            return true;
        }

        public bool Edit(EditArticleCategoryDto command)
        {
            var articleCategory = _articleCategoryRepository.GetBy(command.Id);

            if (articleCategory == null || command.Id != articleCategory.Id)
            {
                return false;
            }

            var slug = command.Slug.FixSlug();
            articleCategory.Edit(command.Title, slug, command.MetaTag,
                command.MetaDescription);
            _articleCategoryRepository.Save();

            return true;
        }

        public List<ArticleCategoryDto> GetAll()
        {
            return _articleCategoryRepository.GetAll()
                .OrderByDescending(x => x.Id)
                .Select(x => new ArticleCategoryDto()
                {
                    Id = x.Id,
                    IsDeleted = x.IsDeleted,
                    Title = x.Title,
                    CreationDate = x.CreationDate.ToShortDateString(),
                }).ToList();
        }

        public EditArticleCategoryDto GetForEdit(long id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);

            return new EditArticleCategoryDto()
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
                MetaDescription = articleCategory.MetaDescription,
                MetaTag = articleCategory.MetaTag,
                Slug = articleCategory.Slug
            };
        }
    }
}
