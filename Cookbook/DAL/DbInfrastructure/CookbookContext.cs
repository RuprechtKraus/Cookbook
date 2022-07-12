using Microsoft.EntityFrameworkCore;
using Cookbook.Models;
using Cookbook.DAL.DbInfrastructure.Configuration;

namespace Cookbook.DAL.DbInfrastructure
{
    public class CookbookContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<IngredientsSection> IngredientsSections { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = RUPRECHTMACHINE\SQLEXPRESS;
                                          Database = Cookbook;
                                          Trusted_Connection = True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new RecipeConfiguration());
            builder.ApplyConfiguration(new RecipeStepConfiguration());
            builder.ApplyConfiguration(new IngredientsSectionConfiguration());
            builder.ApplyConfiguration(new TagConfiguration());
            builder.ApplyConfiguration(new RecipeTagConfiguration());
        }
    }
}