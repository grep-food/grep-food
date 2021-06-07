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
            Console.WriteLine("length " + Baseing.Count());
            foreach (var ids in Baseing)
            {
                Console.WriteLine("id: " + ids.Name + " select: " + ids.isChecked);
                if (ids.isChecked)
                    BaseingChecked.Add(ids);

            }
            foreach (var ids in BaseingChecked)
            {
                Console.WriteLine("id: " + ids.Name + " select: " + ids.isChecked);

            }
            List<RecipeDto> recipes=_dataRepository.Query<RecipeDto>().ToList();

            foreach (var ids in BaseingChecked) { 
                if (BaseingChecked.Count != 0)
                {
                    recipes = recipes.Where(x => x.Name.Equals("Eastern European Kotlety")).ToList();
                    //recipes = recipes.Where(x => x.Name.Equals("Eastern European Kotlety")).ToList();
                } 
            }
            return View(recipes);
        }

    }
}