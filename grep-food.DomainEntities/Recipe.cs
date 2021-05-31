using System;
using System.Collections.Generic;
using System.Text;

namespace grep_food.DomainEntities
{
    public class Recipe
    {
        public Recipe()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public Utilites.Time time { get; set; }

        public decimal Temperature{get; set;}

        public int[] IngredientsID { get; set; } //!!!!!
    }
}
