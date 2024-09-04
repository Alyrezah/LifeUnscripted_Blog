using LifeUnscripted_Blog.Domain.ArticleAgg;

namespace LifeUnscripted_Blog.Domain.UserAgg
{
    public class User
    {
        public string Id { get; private set; }
        public string Email { get; private set; }
        public string FullName { get; private set; }
        public string Password { get; private set; }
        public virtual List<Article> Articles { get; private set; }

        protected User()
        {
            
        }

        public User(string id, string email, string fullName, string password)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Articles = new List<Article>();
        }
    }
}
