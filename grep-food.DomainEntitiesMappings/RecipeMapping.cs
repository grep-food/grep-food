using grep_food.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace grep_food.DomainEntitiesMappings
{
   internal class RecipeMapping : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
           builder.ToTable("Recipes")
            .HasKey(_ => _.Id);
        }
    }
}
