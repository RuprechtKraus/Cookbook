using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Entities.Models;
using Cookbook.DbInfrastructure.Configuration;

namespace Cookbook.DbInfrastructure
{
    public class CookbookDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<IngredientsGroup> Ingredients { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer( @"Server = RUPRECHTMACHINE\SQLEXPRESS;
                                          Database = Cookbook;
                                          Trusted_Connection = True" );
        }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            base.OnModelCreating( builder );

            builder.ApplyConfiguration( new UserConfiguration() );
            builder.ApplyConfiguration( new RecipeConfiguration() );
            builder.ApplyConfiguration( new IngredientsGroupConfiguration() );
            builder.ApplyConfiguration( new StepConfiguration() );
            builder.ApplyConfiguration( new TagConfiguration() );
            builder.ApplyConfiguration( new CategoryConfiguration() );
        }
    }
}
