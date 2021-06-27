using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cookbook.Entities.Models;

namespace Cookbook.DbInfrastructure.Configuration
{
    public class IngredientsGroupConfiguration : IEntityTypeConfiguration<IngredientsGroup>
    {
        public void Configure( EntityTypeBuilder<IngredientsGroup> builder )
        {
            builder.ToTable("IngredientsGroups").HasKey( i => i.Id );

            builder.Property( i => i.Title ).IsRequired().HasMaxLength( 50 );
            builder.Property( i => i.List ).IsRequired().HasMaxLength( 500 );

            builder.HasOne<Recipe>().WithMany( r => r.Ingredients );
        }
    }
}
