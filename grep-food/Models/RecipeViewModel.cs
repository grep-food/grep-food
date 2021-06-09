
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

        public static RecipeViewModel ViewmodelFromDto(RecipeDto dto, IDataRepository _dataRepository)
        {
            var recipeingredients = _dataRepository.Query<RecipeIngredientDto>().Where(x => x.RecipeId == dto.Id).ToList();
            var ingredients = recipeingredients.Select(x => IngredientViewModel.GetFromId(x.IngredientId, _dataRepository));

            return new RecipeViewModel()
            {
                Id = dto.Id,
                Name = dto.Name,
                Time = new Utilities.Time(dto.TimeMinutes),
                Instructions = SeparateInstructions(dto.Instructions),
                Image = dto.Image,

                Ingredients = ingredients.ToList()
            };

        }
        public static RecipeViewModel GetFromId(Guid id, IDataRepository _dataRepository)
        {
            var data = _dataRepository.Query<RecipeDto>().First(x => x.Id == id);
            return ViewmodelFromDto(data, _dataRepository);
        }

        public static string[] SeparateInstructions(string Instructions) => Instructions.Split('\n');

        public static Guid GenerateRandomId(IDataRepository _dataRepository)
        {
            var ListOfRecipes = _dataRepository.Query<RecipeDto>().Select(x => x.Id).ToList();
            DateTime today = DateTime.Now;
            var DateTuple = Tuple.Create(today.Year, today.Month, today.Day);
            int NumberOfRecipes = ListOfRecipes.Count();
            Random RngGod = new Random(DateTuple.GetHashCode());

            var it = ListOfRecipes[RngGod.Next(NumberOfRecipes)];

            return it;
        }
        public bool ContainsIngredient(BaseIngredientViewModel ing)
        {
            foreach (var ingred in Ingredients)
            {
                if (ingred.BaseIngredient.Id == ing.Id) return true;
            }
            return false;

        }
        public bool ContainsMultipleIngredients(IEnumerable<BaseIngredientViewModel> ingreds)
        {
            foreach (var ing in ingreds)
            {
                if (!ContainsIngredient(ing)) return false;

            }
            return true;


        }
    }

}
