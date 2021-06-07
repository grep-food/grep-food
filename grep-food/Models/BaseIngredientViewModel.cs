using System;

namespace grep_food.Models
{
    public class BaseIngredientViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Count() {
            return 0;
        }

    }
}
