using System;
using System.Collections.Generic;


namespace grep_food.DataAccess.Dto
{
    public class RecipeDto
    {
        public RecipeDto()
        {
        }

        public RecipeDto(Guid id, string name, int time, string instructions,  string imagePath)
        {
            Id = id;
            Name = name;
            TimeMinutes = time;
            Instructions = instructions;
           // IngredientsID = ingredientsId;
            Image = imagePath;

          
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public int TimeMinutes { get; set; }

        public string Instructions { get; set; }
       // public Guid[] IngredientsID { get; set; } 
      //  public IEnumerable<Guid> IngredientsID { get; set; }

        public string Image { get; set; }
    }
}
