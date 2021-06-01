using System;
using System.Collections.Generic;
using System.Text;

namespace grep_food.DomainEntities
{
    public class BaseIngredient{
    
        public Guid Id { get; set; }
        public string Name { get; set; }

        public BaseIngredient(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
