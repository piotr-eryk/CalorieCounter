using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalorieCounter.Data;
using CalorieCounter.Model;
using CalorieCounter.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CalorieCounter.Pages.FoodTypes
{
    [Authorize(Roles = SD.AdminAndUser)]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
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
            if (FoodType == null)
            {
                return NotFound();
            }

            _db.FoodType.Remove(FoodType);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}