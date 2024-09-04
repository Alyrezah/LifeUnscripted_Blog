using LifeUnscripted_Blog.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeUnscripted_Blog.Persistence.EfCore.Mappings
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.MetaTag)
                .IsRequired();

            builder.Property(x => x.MetaDescription)
                .IsRequired()
                .HasMaxLength(350);

            builder.HasIndex(x => x.Title).IsUnique();
            builder.HasIndex(x => x.Slug).IsUnique();

            builder.HasMany(x => x.Articles)
                .WithOne(x => x.ArticleCategory).HasForeignKey(x => x.CategoryId);
        }
    }
}
