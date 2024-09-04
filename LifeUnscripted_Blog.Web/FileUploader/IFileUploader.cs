namespace LifeUnscripted_Blog.Web.FileUploader
{
    public interface IFileUploader
    {
        string Upload(IFormFile file , string path);
    }
}
