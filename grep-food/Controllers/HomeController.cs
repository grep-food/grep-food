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

namespace grep_food.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataRepository _dataRepository;
        public HomeController(ILogger<HomeController> logger, IDataRepository dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Recipe()
        {

            var data = _dataRepository.Query<RecipeViewModel>().Take(10).ToArray();
            return View(data.Select(x => new RecipeViewModel
            {
                //    FirstName = x.FirstName,
                //    Id = x.Id,
                //    IdNo = x.IdNo,
                //    LastName = x.LastName
                Id = x.Id,
                Name = x.Name,
                TimeMinutes = x.TimeMinutes,
                Instructions = x.Instructions,
                Image = x.Image

            }));
             
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
