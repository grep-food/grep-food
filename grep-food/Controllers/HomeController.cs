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
using System.Dynamic;
using grep_food.DataAccess.Dto;

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
            return View();

        }
     

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Search()
        {
             var data = _dataRepository.Query<BaseIngredientDto>().Take(15).ToArray();

             return View(data.Select(x => new BaseIngredientViewModel
              {
                  Id = x.Id,
                  Name = x.Name
             }).ToList());
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
