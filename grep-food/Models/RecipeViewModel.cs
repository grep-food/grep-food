using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grep_food.Models
{
    public class RecipeViewModel 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TimeMinutes { get; set; }
        public string Instructions { get; set; }
        public string Image { get; set; }
    }
}
