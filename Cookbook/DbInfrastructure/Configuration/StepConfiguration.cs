using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cookbook.Entities.Models;


namespace Cookbook.DbInfrastructure.Configuration
{
    public class StepConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure( EntityTypeBuilder<Step> builder )
        {
            builder.ToTable( "Steps" ).HasKey( s => s.Id );

            builder.Property( s => s.StepIndex ).IsRequired();
            builder.Property( s => s.Desc ).IsRequired().HasMaxLength( 1000 );

            builder.HasOne<Recipe>().WithMany( r => r.Steps ).HasForeignKey( s => s.RecipeId );
        }
    }
}
