using LifeUnscripted_Blog.Application;
using LifeUnscripted_Blog.Application.Contracts.Article;
using LifeUnscripted_Blog.Application.Contracts.ArticleCategory;
using LifeUnscripted_Blog.Application.Contracts.Comment;
using LifeUnscripted_Blog.Domain.ArticleAgg;
using LifeUnscripted_Blog.Domain.ArticleCategoryAgg;
using LifeUnscripted_Blog.Domain.CommentAgg;
using LifeUnscripted_Blog.Infra.Query.ArticleCategories;
using LifeUnscripted_Blog.Infra.Query.Articles;
using LifeUnscripted_Blog.Persistence.EfCore;
using LifeUnscripted_Blog.Persistence.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LifeUnscripted_Blog.Infra.ServicesRegistration
{
    public static class ServicesRegistration
    {
        public static void Configure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LifeUnscriptedDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();

            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleApplication, ArticleApplication>();

            services.AddTransient<ICommentRepository,CommentRepository>();
            services.AddTransient<ICommentApplication, CommentApplication>();

            services.AddTransient<IArticleQuery, ArticleQuery>();
            services.AddTransient<IArticleCategoriesQuery, ArticleCategoriesQuery>();
        }
    }
}
