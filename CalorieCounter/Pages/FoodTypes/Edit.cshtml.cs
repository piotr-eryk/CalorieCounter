using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CalorieCounter.Data;
using CalorieCounter.Model;
using Microsoft.AspNetCore.Authorization;
using CalorieCounter.Utility;

namespace CalorieCounter.Pages.FoodTypes
{
    [Authorize(Roles = SD.AdminAndUser)]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public FoodType FoodType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodType = await _db.FoodType.FirstOrDefaultAsync(m => m.Id == id);

            if (FoodType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var FoodFromDb = await _db.FoodType.FirstOrDefaultAsync(s => s.Id == FoodType.Id);
            FoodFromDb.Name = FoodType.Name;
            FoodFromDb.Calorie = FoodType.Calorie;
            await _db.SaveChangesAsync();
          
            return RedirectToPage("./Index");
        }

    }
}
