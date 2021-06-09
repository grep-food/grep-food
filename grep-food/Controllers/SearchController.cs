using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using grep_food.DomainEntities;
using grep_food.Models;
using grep_food.DataAccess;
using grep_food.DataAccess.Dto;

namespace grep_food.Controllers
{
    public class SearchController : Controller
    {
        private readonly IDataRepository _dataRepository;
        public SearchController(IDataRepository dataRepository)
        {
            Console.WriteLine($"dataRepo: '{_dataRepository}'");
            _dataRepository = dataRepository;
        }
        [HttpPost]
        public IActionResult Index(List<BaseIngredientViewModel> Baseing)
        {
            List<BaseIngredientViewModel> BaseingChecked = new List<BaseIngredientViewModel>();
            foreach (var ids in Baseing)
            {
                //  Console.WriteLine("id: " + ids.Name + " select: " + ids.isChecked);
                if (ids.isChecked)
                    BaseingChecked.Add(ids);

            }

            List<RecipeViewModel> recipes= _dataRepository.Query<RecipeDto>().ToList().Select(x=>RecipeViewModel.ViewmodelFromDto(x,_dataRepository)).ToList();
            List<RecipeViewModel> RecipeIntersection = GetIntersectionOfRecipes(BaseingChecked,recipes);




            return View(RecipeIntersection);
        }
        public List<RecipeViewModel> GetIntersectionOfRecipes(List<BaseIngredientViewModel> BaseIngredients, List<RecipeViewModel> Recipes)
        {
            return Recipes.Where(x => x.ContainsMultipleIngredients(BaseIngredients)).ToList();
        }

    }

}