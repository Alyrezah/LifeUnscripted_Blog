using LifeUnscripted_Blog.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeUnscripted_Blog.Persistence.EfCore.Mappings
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.MetaTag)
                .IsRequired();

            builder.Property(x => x.ShortDescription)
               .IsRequired()
               .HasMaxLength(350);

            builder.Property(x => x.MetaDescription)
            .IsRequired()
            .HasMaxLength(350);

            builder.Property(x => x.Description)
            .IsRequired();

            builder.Property(x => x.CategoryId)
            .IsRequired();

            builder.Property(x => x.AuthorId)
           .IsRequired();

            builder.HasIndex(x => x.Title).IsUnique();
            builder.HasIndex(x => x.Slug).IsUnique();

            builder.HasOne(x => x.ArticleCategory)
                .WithMany(x => x.Articles).HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Author)
                .WithMany(x => x.Articles).HasForeignKey(x => x.AuthorId);

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.Article).HasForeignKey(x => x.ArticleId);
        }
    }
}
