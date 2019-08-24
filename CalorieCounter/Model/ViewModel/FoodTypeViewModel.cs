using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounter.Model.ViewModel
{
    public class FoodTypeViewModel
    {

        public DailyFood DailyFood { get; set; }
        public FoodDetails FoodDetails { get; set; }
        public FoodHeader FoodHeader { get; set; }

        public List<FoodType> FoodTypeList { get; set; }
        public List<ServiceAddFood> ServiceAddFood { get; set; }
    }
}
