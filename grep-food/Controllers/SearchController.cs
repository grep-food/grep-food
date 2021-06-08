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
        //public HomeController(ILogger<HomeController> logger, IDataRepository dataRepository)
        public SearchController(IDataRepository dataRepository)
        {
            // _logger = logger;
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
            /*  foreach (var ids in BaseingChecked)
              {
                  Console.WriteLine("id: " + ids.Name + " select: " + ids.isChecked);

              }*/
            List<RecipeDto> recipes = new List<RecipeDto>(); //_dataRepository.Query<RecipeDto>().ToList();
            List<RecipeIngredientDto> recipesIngredient = new List<RecipeIngredientDto>();
            List<IngredientDto> ingredients = new List<IngredientDto>();
           
            if (BaseingChecked.Count != 0)
            {
                foreach (var ids in BaseingChecked) {
                    ingredients = _dataRepository.Query<IngredientDto>().Where(x => x.BaseIngredient_ID == ids.Id).ToList();
                    
                    //recipes = recipes.Where(x => x.Name.Equals("Eastern European Kotlety")).ToList();
                } 
            }
            if (ingredients.Count != 0)
            {
                foreach (var ids in ingredients)
                {
                    recipesIngredient = _dataRepository.Query<RecipeIngredientDto>().Where(x => x.IngredientId == ids.Id).ToList();

                    //recipes = recipes.Where(x => x.Name.Equals("Eastern European Kotlety")).ToList();
                }
            }
            Console.WriteLine(ingredients.Count());
            foreach (var ids in ingredients)
            {
                Console.WriteLine("id: " + ids.Id + " select: " + ids.FullName);

            }
            if (recipesIngredient.Count != 0)
            {
                foreach (var _recipe in recipesIngredient)
                {
                    recipes = _dataRepository.Query<RecipeDto>().Where(x => x.Id== _recipe.RecipeId).ToList();
                }
            }
            Console.WriteLine(recipes.Count());
            foreach (var ids in recipes)
            {
                Console.WriteLine("id: " + ids.Id + " select: " + ids.Name);

            }
            return View(recipes);
        }

    }
}