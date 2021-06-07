using grep_food.DataAccess;
using grep_food.DataAccess.Dto;
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
            return View(RecipeViewModel.GetFromId(Id,_dataRepository));
          
        }
      

        

      


    }

}

