using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using grep_food.DomainEntities;

namespace grep_food.Models
{
    public class RecipeListModel
    {
        public IEnumerable<BaseIngredient> SelectedIngredients{ get; set; }
        public IEnumerable<Recipe> FindRecipes{ get; set; }
    }
}
