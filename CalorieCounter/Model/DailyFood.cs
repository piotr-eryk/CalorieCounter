using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounter.Model
{
    public class DailyFood
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Day { get; set; }

        public int MaxCalories { get; set; }
        public int MinCalories { get; set; }
        public int OverAbundance { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}
