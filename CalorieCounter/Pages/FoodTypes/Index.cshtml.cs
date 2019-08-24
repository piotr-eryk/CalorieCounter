using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalorieCounter.Data;
using CalorieCounter.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CalorieCounter.Pages.FoodTypes
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public IList<FoodType> FoodType { get; set; }

        public async Task<IActionResult> OnGet()
        {
            FoodType = await _db.FoodType.ToListAsync();
            return Page();
        }
    }
}