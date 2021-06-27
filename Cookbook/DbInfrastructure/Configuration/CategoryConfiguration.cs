using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cookbook.Entities.Models;

namespace Cookbook.DbInfrastructure.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure( EntityTypeBuilder<Category> builder )
        {
            builder.ToTable( "Categories" ).HasKey( c => c.Id );

            builder.Property( c => c.Title ).IsRequired().HasMaxLength( 30 );
            builder.Property( c => c.Desc ).IsRequired().HasMaxLength( 150 );
        }
    }
}
