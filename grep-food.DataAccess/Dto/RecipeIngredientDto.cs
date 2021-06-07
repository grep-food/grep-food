using System;
using System.ComponentModel.DataAnnotations;

namespace grep_food.DataAccess.Dto
{
    public class RecipeIngredientDto
    {
        
        public Guid RecipeId { get; set; }
       
        public Guid IngredientId { get; set; }

        public RecipeIngredientDto(Guid recipeId, Guid ingredientId)
        {
            RecipeId = recipeId;
            IngredientId = ingredientId;
        }
    }
}
