using System;
using System.Collections.Generic;
using System.Text;
using grep_food.DomainEntities;

namespace grep_food.DataAccess.Dto
{
    class IngredientDto
    {
        public IngredientDto()
        {
        }

        public IngredientDto(Guid id, string name, BaseIngredient baseIngredient,decimal quantity,string unit)
        {
            Id = id;
            Name = name;
            BaseIngredient = baseIngredient;
            Quantity = quantity;
            Unit = unit;

        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public BaseIngredient BaseIngredient { get; set; }
        public decimal Quantity { get; set; }

        public string Unit { get; set; }
    }
}
