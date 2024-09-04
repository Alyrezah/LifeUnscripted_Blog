namespace LifeUnscripted_Blog.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleDto> GetAll();
        bool Create(CreateArticleDto command);
        EditArticleDto GetForEdit(long id);
        bool Edit(EditArticleDto command);
        bool ChangeIsDeleted(long id);
    }
}
