using grep_food.DataAccess;
using grep_food.DataAccess.Dto;
using System;
using System.Linq;

namespace grep_food.Models
{
    public class IngredientViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public BaseIngredientViewModel BaseIngredient { get; set; }

        public static IngredientViewModel GetFromId(Guid id,IDataRepository _dataRepository)
        {
            var query = _dataRepository.Query<IngredientDto>().First(x => x.Id == id);
            return new IngredientViewModel()
            {
                Id = query.Id,
                Name = query.FullName,
                BaseIngredient = BaseIngredientViewModel.GetFromId(query.BaseIngredient_ID, _dataRepository)


            };


        }



    }

}