using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounter.Model
{
    public class FoodHeader
    {
        public int Id { get; set; }
        public int Calories { get; set; }
        [Required]
        public int TotalCalories { get; set; }
        public string Details { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MMM yyyy dd}")]
        public DateTime DateAdded { get; set; }

        public int DailyFoodId { get; set; }

        [ForeignKey("DailyFoodId")]
        public virtual DailyFood DailyFood { get; set; }
    }
}
