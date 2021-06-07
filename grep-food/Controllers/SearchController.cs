using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using grep_food.DomainEntities;
using grep_food.Models;
namespace grep_food.Controllers
{
    public class SearchController : Controller
    {
        [HttpPost]
        public IActionResult Index(BaseIngredientViewModel model)
        {
            //Console.WriteLine(model.Name.ToString());
            Console.WriteLine("AAA");
            Console.WriteLine( model.Count());
            for (int i = 0; i < model.Count(); i++) { 
                Console.WriteLine(model.Name);
                Console.WriteLine("BBB");
            }
            return View();
        }
    }
}
