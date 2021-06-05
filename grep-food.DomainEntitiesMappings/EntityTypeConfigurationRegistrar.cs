using System;
using Microsoft.EntityFrameworkCore;
using grep_food.DataAccess;

namespace grep_food.DomainEntitiesMappings
{
    public class EntityTypeConfigurationRegistrar : IEntityTypeConfigurationRegistrar
    {
        public void ApplyConfiguration(ModelBuilder modelBuilder)
        {
             modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS_UTF8");
            modelBuilder.ApplyConfiguration(new RecipeMapping());
            modelBuilder.ApplyConfiguration(new BaseIngredientMapping());
            modelBuilder.ApplyConfiguration(new IngredientMapping());
            modelBuilder.ApplyConfiguration(new RecipeIngredientMapping());
        }
    }

}
