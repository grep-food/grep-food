
using grep_food.DataAccess;
using grep_food.DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grep_food.Models
{
    public class RecipeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Utilities.Time Time { get; set; }
        public string[] Instructions { get; set; }
        public string Image { get; set; }

        public List<IngredientViewModel> Ingredients { get; set; }

        public static RecipeViewModel GetFromId(Guid id, IDataRepository _dataRepository)
        {
            var data = _dataRepository.Query<RecipeDto>().First(x => x.Id == id);


            var recipeingredients = _dataRepository.Query<RecipeIngredientDto>().Where(x => x.RecipeId == id).ToList();
            var ingredients = recipeingredients.Select(x => IngredientViewModel.GetFromId(x.IngredientId,_dataRepository));

            return new RecipeViewModel()
            {
                Id = data.Id,
                Name = data.Name,
                Time =  new Utilities.Time(data.TimeMinutes),
                Instructions = SeparateInstructions(data.Instructions),
                Image = data.Image,

                Ingredients = ingredients.ToList()
            };
        }

        public static string[] SeparateInstructions(string Instructions) => Instructions.Split('\n');
        
        public static Guid GenerateRandomId(IDataRepository _dataRepository)
        {
            var ListOfRecipes= _dataRepository.Query<RecipeDto>().Select(x=>x.Id).ToList();
            DateTime today = DateTime.Now;
            var DateTuple = Tuple.Create(today.Year, today.Month, today.Day);
            int NumberOfRecipes = ListOfRecipes.Count();
            Random RngGod = new Random(DateTuple.GetHashCode());

            var it =ListOfRecipes[RngGod.Next(NumberOfRecipes)];

            return it;
        }
    }
    
}
