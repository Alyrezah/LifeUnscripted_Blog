namespace LifeUnscripted_Blog.Domain.Common
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; private set; }
        public DateTime CreationDate { get; private set; }

        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }
    }

    public abstract class BaseEntity : BaseEntity<long>
    {

    }
}
