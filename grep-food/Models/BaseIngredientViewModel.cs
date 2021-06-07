using grep_food.DataAccess;
using grep_food.DataAccess.Dto;
using System;
using System.Linq;
using System.Collections.Generic;


namespace grep_food.Models
{
    public class BaseIngredientViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }



        public static BaseIngredientViewModel GetFromId(Guid id, IDataRepository _dataRepository)
        {
            var data = _dataRepository.Query<BaseIngredientDto>().First(x => x.Id == id);
            return new BaseIngredientViewModel()
            {
                Id = data.Id,
                Name = data.Name

            };
        }
        public bool isChecked{ get; set; }

      

        

    }

   /*public class BaseIngredientsList
    {
        public List<BaseIngredientViewModel> _listOfBaseIngredients { get; set; }
    }*/
}
