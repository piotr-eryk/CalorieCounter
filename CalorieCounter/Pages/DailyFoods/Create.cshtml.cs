using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CalorieCounter.Data;
using CalorieCounter.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.DailyFoods
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public DailyFood DailyFood { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(string userId=null)
        {
            DailyFood = new DailyFood();
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }
            DailyFood.UserId = userId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.DailyFood.Add(DailyFood);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index", new { userId = DailyFood.UserId });
        }
    }
}