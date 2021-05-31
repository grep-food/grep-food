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

        public DateTime Time { get; set; }

        public string Instructions { get; set; }
        public Guid[] IngredientsID { get; set; } //!!!!!
    }
}
