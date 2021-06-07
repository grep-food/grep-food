using System;
using System.Collections.Generic;

namespace grep_food.Models
{
    public class BaseIngredientViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool isChecked{ get; set; }

        public int Count() {
            return 0;
        }

    }

   /*public class BaseIngredientsList
    {
        public List<BaseIngredientViewModel> _listOfBaseIngredients { get; set; }
    }*/
}
