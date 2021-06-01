using System;
using System.Collections.Generic;
using System.Text;

namespace grep_food.DomainEntities
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public BaseIngredient BaseIngredient  { get; set; }
        public decimal Quantity { get; set; }

        public string Unit { get; set; }

        
        //for the ingredients functionality LATER 
        //public bool Selected { get; set; }
    }
}
