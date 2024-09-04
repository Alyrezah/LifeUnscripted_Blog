namespace LifeUnscripted_Blog.Application.Contracts.Common
{
    public abstract class BaseApplicationDto
    {
        public long Id { get; set; }
        public string CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
