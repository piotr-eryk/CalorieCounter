using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounter.Model.ViewModel
{
    public class RegisteredViewModel
    {
        public ApplicationUser UserObj { get; set; }
        public IEnumerable<DailyFood> DailyFoods { get; set; }
    }
}
