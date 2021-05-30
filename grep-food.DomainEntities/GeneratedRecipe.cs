using System;
using System.Collections.Generic;
using System.Text;

namespace grep_food.DomainEntities
{
    public class GeneratedRecipe
    {
        public Guid UserId { get; }
        public Guid RecipeId { get; }

        public Recipe GenerateRecipe(int id) {
            Recipe _recipe = new Recipe();
            //select random from db
            return _recipe;
        }
    }
}
