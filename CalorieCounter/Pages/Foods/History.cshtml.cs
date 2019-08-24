using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalorieCounter.Data;
using CalorieCounter.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CalorieCounter.Pages.Foods
{
    public class HistoryModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public HistoryModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public List<FoodHeader> FoodHeader { get; set; }

        public string UserId { get; set; }

        public async Task OnGet(int foodId)
        {
            FoodHeader = await _db.FoodHeader.Include(s => s.DailyFood).Include(c => c.DailyFood.ApplicationUser).Where(c => c.DailyFoodId == foodId).ToListAsync();

            UserId = _db.DailyFood.Where(u => u.Id == foodId).ToList().FirstOrDefault().UserId;
        }
    }
}