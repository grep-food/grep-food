using grep_food.DataAccess.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace grep_food.DomainEntitiesMappings
{
    internal class RecipeIngredientMapping : IEntityTypeConfiguration<RecipeIngredientDto>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredientDto> builder)
        {
            builder.ToTable("RecipeIngredients")
                .HasKey(c=> new {c.IngredientId,c.RecipeId });

        }

    }

}
