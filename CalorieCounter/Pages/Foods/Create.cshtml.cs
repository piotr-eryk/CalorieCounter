using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalorieCounter.Data;
using CalorieCounter.Model;
using CalorieCounter.Model.ViewModel;
using CalorieCounter.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CalorieCounter.Pages.Foods
{
    [Authorize(Roles=SD.AdminAndUser)]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public FoodTypeViewModel FoodTypeVM { get; set; } 

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet(int foodId)
        {
            FoodTypeVM = new FoodTypeViewModel
            {
                DailyFood = await _db.DailyFood.Include(c => c.ApplicationUser).FirstOrDefaultAsync(c => c.Id == foodId),
                FoodHeader = new FoodHeader()
            };

            List<String> lstFoodTypeInFoodCart = _db.ServiceAddFood //po kolei migracje
                                                    .Include(c => c.FoodType)
                                                    .Where(c => c.FoodId == foodId)
                                                    .Select(c => c.FoodType.Name)
                                                    .ToList();

            IQueryable<FoodType> lstService = from s in _db.FoodType
                                              where !(lstFoodTypeInFoodCart.Contains(s.Name))
                                              select s;

            FoodTypeVM.FoodTypeList = lstService.ToList();

            FoodTypeVM.ServiceAddFood = _db.ServiceAddFood.Include(c => c.FoodType).Where(c => c.FoodId == foodId).ToList();
            FoodTypeVM.FoodHeader.TotalCalories = 0;

            foreach (var item in FoodTypeVM.ServiceAddFood)
            {
                FoodTypeVM.FoodHeader.TotalCalories += item.FoodType.Calorie;
            }

            return Page();

        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                FoodTypeVM.FoodHeader.DateAdded = DateTime.Now;
                FoodTypeVM.ServiceAddFood = _db.ServiceAddFood.Include(c => c.FoodType).Where(c => c.FoodId == FoodTypeVM.DailyFood.Id).ToList();
                foreach (var item in FoodTypeVM.ServiceAddFood)
                {
                    FoodTypeVM.FoodHeader.TotalCalories += item.FoodType.Calorie;
                }
                FoodTypeVM.FoodHeader.DailyFoodId = FoodTypeVM.DailyFood.Id;

                _db.FoodHeader.Add(FoodTypeVM.FoodHeader);
                await _db.SaveChangesAsync();

                foreach (var detail in FoodTypeVM.ServiceAddFood)
                {
                    FoodDetails serviceDetails = new FoodDetails
                    {
                        FoodHeaderId = FoodTypeVM.FoodHeader.Id,
                        FoodName = detail.FoodType.Name,
                        FoodCalories = detail.FoodType.Calorie,
                        FoodTypeId = detail.FoodTypeId
                    };

                    _db.Food.Add(serviceDetails); //Food to nazwa klasy FoodDetails, przepraszam za upośledzenie

                }
                _db.ServiceAddFood.RemoveRange(FoodTypeVM.ServiceAddFood);

                await _db.SaveChangesAsync();

                return RedirectToPage("../DailyFoods/Index", new { userId = FoodTypeVM.DailyFood.UserId });
            }

            return Page();
        }



        public async Task<IActionResult> OnPostAddToCart()
        {
            ServiceAddFood objServiceCart = new ServiceAddFood()
            {
                FoodId = FoodTypeVM.DailyFood.Id,
                FoodTypeId = FoodTypeVM.FoodDetails.FoodTypeId
            };

            _db.ServiceAddFood.Add(objServiceCart);
            await _db.SaveChangesAsync();
            return RedirectToPage("Create", new { foodId = FoodTypeVM.DailyFood.Id });
        }

        public async Task<IActionResult> OnPostRemoveFromCart(int foodTypeId)
        {
            ServiceAddFood objServiceCart = _db.ServiceAddFood
                .FirstOrDefault(u => u.FoodId == FoodTypeVM.DailyFood.Id && u.FoodTypeId == foodTypeId);


            _db.ServiceAddFood.Remove(objServiceCart);
            await _db.SaveChangesAsync();
            return RedirectToPage("Create", new { foodId = FoodTypeVM.DailyFood.Id });
        }
    }
}