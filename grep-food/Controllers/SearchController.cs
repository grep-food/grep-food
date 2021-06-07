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
        public IActionResult Index(List<BaseIngredientViewModel> Baseing)
        {
                Console.WriteLine("length " + Baseing.Count());
                foreach (var ids in Baseing)
                {
                    Console.WriteLine("id: " + ids.Name + " select: " + ids.isChecked);



                }

                return View();
        }
    }
}
