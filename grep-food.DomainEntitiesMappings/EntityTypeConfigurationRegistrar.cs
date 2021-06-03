using System;
using Microsoft.EntityFrameworkCore;
using grep_food.DataAccess;

namespace grep_food.DomainEntitiesMappings
{
    public class EntityTypeConfigurationRegistrar : IEntityTypeConfigurationRegistrar
    {
        public void ApplyConfiguration(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new RecipeMapping());
        }
    }
}
