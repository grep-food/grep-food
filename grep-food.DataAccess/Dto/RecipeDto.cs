using System;
using System.Collections.Generic;


namespace grep_food.DataAccess.Dto
{
    public class RecipeDto
    {
        public RecipeDto()
        {
        }

        public RecipeDto(Guid id, string name, Utilites.Time time, string instructions, List<Guid> ingredientsId, string imagePath)
        {
            Id = id;
            Name = name;
            Time = time;
            Instructions = instructions;
            IngredientsID = ingredientsId;
            ImagePath = imagePath;

          
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Utilites.Time Time { get; set; }

        public string Instructions { get; set; }
       // public Guid[] IngredientsID { get; set; } 
        public List<Guid> IngredientsID { get; set; }

        public string ImagePath { get; set; }
    }
}
