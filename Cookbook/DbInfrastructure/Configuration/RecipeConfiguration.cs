using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cookbook.Entities.Models;

namespace Cookbook.DbInfrastructure.Configuration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure( EntityTypeBuilder<Recipe> builder )
        {
            builder.ToTable( "Recipes" ).HasKey( r => r.Id );

            builder.Property( r => r.Title ).IsRequired().HasMaxLength( 60 );
            builder.Property( r => r.Desc ).IsRequired().HasMaxLength( 150 );
            builder.Property( r => r.Likes ).HasDefaultValue( 0 );
            builder.Property( r => r.Favs ).HasDefaultValue( 0 );
            builder.Property( r => r.CookingTime ).IsRequired();
            builder.Property( r => r.Servings ).IsRequired();

            builder.HasOne<User>().WithMany( u => u.Recipes ).HasForeignKey(r => r.UserId);
            builder.HasMany( r => r.Tags ).WithMany( t => t.Recipes );
            builder.HasMany( r => r.Ingredients );
            builder.HasMany( r => r.Steps );
        }
    }
}
