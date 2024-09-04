using LifeUnscripted_Blog.Domain.ArticleAgg;
using LifeUnscripted_Blog.Domain.ArticleCategoryAgg;
using LifeUnscripted_Blog.Domain.CommentAgg;
using LifeUnscripted_Blog.Domain.UserAgg;
using LifeUnscripted_Blog.Persistence.EfCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace LifeUnscripted_Blog.Persistence.EfCore
{
    public class LifeUnscriptedDbContext : DbContext
    {
        public LifeUnscriptedDbContext(DbContextOptions<LifeUnscriptedDbContext> options) : base(options)
        {

        }

        #region Db Sets

        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new CommentMapping());



            base.OnModelCreating(modelBuilder);
        }
    }
}
