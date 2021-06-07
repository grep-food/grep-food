using Microsoft.EntityFrameworkCore;
using grep_food.DomainEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace grep_food.DomainEntitiesMappings
{
    internal class BaseIngredientMapping : IEntityTypeConfiguration<BaseIngredient>
    {
        public void Configure(EntityTypeBuilder<BaseIngredient> builder)
        {
            builder.ToTable("BaseIngredients")
             .HasKey(_ => _.Id);
        }
    }

}
