using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounter.Model
{
    public class ServiceAddFood
    {

        public int Id { get; set; }
        public int FoodId { get; set; }
        public int FoodTypeId { get; set; }

        [ForeignKey("FoodId")]
        public virtual DailyFood DailyFood { get; set; }

        [ForeignKey("FoodTypeId")]
        public virtual FoodType FoodType { get; set; }
    }
}
