namespace LifeUnscripted_Blog.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryDto> GetAll();
        bool Create(CreateArticleCategoryDto command);
        EditArticleCategoryDto GetForEdit(long id);
        bool Edit(EditArticleCategoryDto command);
        bool ChangeIsDeleted(long id);
    }
}
