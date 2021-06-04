using grep_food.DataAccess;
using grep_food.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grep_food.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IDataRepository _dataRepository;
        public RecipeController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public IActionResult Index(Guid Id)
        {
            Console.WriteLine($"id:'{Id}'");
            return View();
        }

        
        
        public IActionResult Recipe(string name)
        {

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



    }
}
