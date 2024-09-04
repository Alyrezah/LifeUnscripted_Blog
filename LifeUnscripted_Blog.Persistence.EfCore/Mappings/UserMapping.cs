using LifeUnscripted_Blog.Domain.UserAgg;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeUnscripted_Blog.Persistence.EfCore.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.FullName)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(x => x.Password)
            .IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x => x.Articles)
                .WithOne(x => x.Author).HasForeignKey(x => x.AuthorId);

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            string password = hasher.HashPassword(null, "123");

            builder.HasData(
                new User("A081407B-FD76-429B-ACA5-1A1158F6B91E", "alireza80heydari@gmail.com",
                "Alireza Heydari", password)
                );
        }
    }
}
