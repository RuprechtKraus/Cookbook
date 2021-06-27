using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cookbook.Entities.Models;

namespace Cookbook.DbInfrastructure.Configuration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure( EntityTypeBuilder<Tag> builder )
        {
            builder.ToTable( "Tags" ).HasKey( t => t.Id );

            builder.Property( t => t.Name ).IsRequired().HasMaxLength( 20 );

            builder.HasMany( t => t.Recipes ).WithMany( r => r.Tags );
        }
    }
}
