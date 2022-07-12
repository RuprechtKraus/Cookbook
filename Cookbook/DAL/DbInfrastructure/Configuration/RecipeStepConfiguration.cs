using Cookbook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookbook.DAL.DbInfrastructure.Configuration
{
    public class RecipeStepConfiguration : IEntityTypeConfiguration<RecipeStep>
    {
        public void Configure(EntityTypeBuilder<RecipeStep> builder)
        {
            builder.ToTable("RecipeStep");
            builder.Property(s => s.StepIndex).IsRequired();
            builder.Property(s => s.Description).IsRequired().HasMaxLength(1000);
        }
    }
}