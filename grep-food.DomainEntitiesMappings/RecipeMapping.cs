using grep_food.DomainEntities;
using grep_food.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace grep_food.DomainEntitiesMappings
{
   internal class RecipeMapping : IEntityTypeConfiguration<RecipeViewModel>
    {
        public void Configure(EntityTypeBuilder<RecipeViewModel> builder)
        {
           builder.ToTable("Recipes")
            .HasKey(_ => _.Id);
        }
    }
}
