using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grep_food.Models
{
    public class RecipeModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Utilites.Time Time { get; set; }

        public string Instructions { get; set; }
        public List<Guid> IngredientsID { get; set; } 

        public string ImagePath { get; set; }
    }
}
