using grep_food.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using grep_food.DataAccess;
using grep_food.DomainEntities;
//using Tap2021Demo.Infrastructure.DataAccess;

namespace grep_food.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;
        private readonly IDataRepository _dataRepository;
        //public HomeController(ILogger<HomeController> logger, IDataRepository dataRepository)
        public HomeController(IDataRepository dataRepository)
        {
            // _logger = logger;
            Console.WriteLine($"dataRepo: '{_dataRepository}'");
            _dataRepository = dataRepository;
        }

        public IActionResult Index()
        {
            var data2 = _dataRepository.Query<RecipeViewModel>().OrderBy(recipe=>recipe.Name).First();
            //Console.WriteLine($"data: '{data2}' data-siz '{data2.Id}'");
            
            
            return Recipe(data2.Name);

        }
        public IActionResult Recipe(string name)
        {
            Console.WriteLine($"Retzipe neim: '{name}'");
            var data = _dataRepository.Query<RecipeViewModel>().Take(10).ToArray();
            return View(data.Select(x => new RecipeViewModel
            {
               
                Id = x.Id,
                Name = x.Name,
                TimeMinutes = x.TimeMinutes,
                Instructions = x.Instructions,
                Image = x.Image

            }));
             
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
