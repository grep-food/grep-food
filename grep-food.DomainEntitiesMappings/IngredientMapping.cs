using grep_food.DataAccess.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace grep_food.DomainEntitiesMappings
{
    internal class IngredientMapping : IEntityTypeConfiguration<IngredientDto>
    {
        public void Configure(EntityTypeBuilder<IngredientDto> builder)
        {
            builder.ToTable("Ingredients")
             .HasKey(_ => _.Id);
            
        }
    }
}
