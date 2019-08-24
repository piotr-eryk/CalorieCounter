using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalorieCounter.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CalorieCounter.Model.ViewModel;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace CalorieCounter.Pages.DailyFoods
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        [BindProperty]
        public RegisteredViewModel CustVM { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet(string userId = null)
        {
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }


            CustVM = new RegisteredViewModel()
            {
                DailyFoods = await _db.DailyFood.Where(c => c.UserId == userId).ToListAsync(),
                UserObj = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == userId)
            };

            return Page();
        }




    }
}