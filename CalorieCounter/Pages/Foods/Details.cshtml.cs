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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public FoodHeader foodHeader { get; set; }
        public List<FoodDetails> foodDetails { get; set; }

        public void OnGet(int dailyId)
        {
            foodHeader = _db.FoodHeader.Include(s => s.DailyFood).Include(s => s.DailyFood.ApplicationUser).FirstOrDefault(s => s.Id == dailyId);
            foodDetails = _db.Food.Where(s => s.FoodHeaderId == dailyId).ToList(); //food to tak naprawde fooddetails bo jestem debilem
        }
    }
}