using Cookbook.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookbook.DAL.DbInfrastructure.Configuration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipe");
            builder.Property(r => r.Name).HasMaxLength(50);
            builder.Property(r => r.Description).HasMaxLength(1000);
            builder.Property(r => r.TimesLiked).HasDefaultValue(0);
            builder.Property(r => r.TimesFavorited).HasDefaultValue(0);
            builder.Property(r => r.CookingTimeInSeconds).IsRequired();
            builder.Property(r => r.ServingsAmount).IsRequired();
        }
    }
}