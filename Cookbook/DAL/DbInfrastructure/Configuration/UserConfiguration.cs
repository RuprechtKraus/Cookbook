using Cookbook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookbook.DAL.DbInfrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(u => u.Name).IsRequired().HasMaxLength(20);
            builder.Property(u => u.Login).IsRequired().HasMaxLength(20);
            builder.Property(u => u.About).HasMaxLength(1000);
            builder.Property(u => u.RecipesCount).HasDefaultValue(0);
            builder.Property(u => u.LikesCount).HasDefaultValue(0);
            builder.Property(u => u.FavoritesCount).HasDefaultValue(0);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(512);
            builder.Property(u => u.PasswordSalt).IsRequired().HasMaxLength(128);
        }
    }
}