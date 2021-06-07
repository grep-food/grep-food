using System;
using System.Collections.Generic;
using System.Text;

namespace grep_food.DataAccess.Dto
{
    public class BaseIngredientDto
    {
        
        public BaseIngredientDto(Guid id, string name)
        {
            Id = id;
            Name = name;

        }

        public Guid Id { get; set; }
        public string Name { get; set; }



    }

}
