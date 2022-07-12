using Cookbook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookbook.DAL.DbInfrastructure.Configuration
{
    public class IngredientsSectionConfiguration : IEntityTypeConfiguration<IngredientsSection>
    {
        public void Configure(EntityTypeBuilder<IngredientsSection> builder)
        {
            builder.ToTable("IngredientsSection");
            builder.Property(s => s.Name).IsRequired().HasMaxLength(20);
            builder.Property(s => s.Products).IsRequired().HasMaxLength(500);
        }
    }
}