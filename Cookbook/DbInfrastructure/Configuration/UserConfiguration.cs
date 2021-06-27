using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cookbook.Entities.Models;

namespace Cookbook.DbInfrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure( EntityTypeBuilder<User> builder )
        {
            builder.ToTable( "Users" ).HasKey( u => u.Id );

            builder.Property( u => u.Name ).IsRequired().HasMaxLength( 50 );
            builder.Property( u => u.Login ).IsRequired().HasMaxLength( 20 );
            builder.Property( u => u.Password ).IsRequired().HasMaxLength( 20 );
            builder.Property( u => u.About ).HasMaxLength( 1000 );

            builder.HasMany( u => u.Recipes );
        }
    }
}
