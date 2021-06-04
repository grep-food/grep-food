using grep_food.DataAccess.Dto;
using grep_food.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace grep_food.DomainEntitiesMappings
{
    internal class RecipeMapping : IEntityTypeConfiguration<RecipeDto>
    {
        public void Configure(EntityTypeBuilder<RecipeDto> builder)
        {
           builder.ToTable("Recipes")
            .HasKey(_ => _.Id);
        }
    }
}
