using System;
using System.Collections.Generic;
using System.Text;
using grep_food.DomainEntities;

namespace grep_food.DataAccess.Dto
{
    public class IngredientDto
    {
        public IngredientDto()
        {
        }

        public IngredientDto(Guid id, string name, Guid baseIngredient)
        {
            Id = id;
            FullName = name;
            BaseIngredient_ID = baseIngredient;
            
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Guid BaseIngredient_ID { get; set; }
      
    }
}
