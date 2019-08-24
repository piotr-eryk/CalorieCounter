using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounter.Model
{
    public class FoodDetails
    {
        public int Id { get; set; }

        public int FoodHeaderId { get; set; }
        [ForeignKey("FoodHeaderId")]
        public virtual FoodHeader FoodHeader { get; set; }

        [Display(Name = "FoodType")]
        public int FoodTypeId { get; set; }
        [ForeignKey("FoodTypeId")]
        public virtual FoodType FoodType { get; set; }

        public int FoodCalories { get; set; }
        public string FoodName { get; set; }
    }
}
