using Microsoft.EntityFrameworkCore;
using grep_food.DomainEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using grep_food.DataAccess.Dto;

namespace grep_food.DomainEntitiesMappings
{
    internal class BaseIngredientMapping : IEntityTypeConfiguration<BaseIngredientDto>
    {
        public void Configure(EntityTypeBuilder<BaseIngredientDto> builder)
        {
            builder.ToTable("BaseIngredients")
             .HasKey(_ => _.Id);
        }
    }

}
