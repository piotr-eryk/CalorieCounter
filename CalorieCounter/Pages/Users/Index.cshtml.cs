using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieCounter.Data;
using CalorieCounter.Model;
using CalorieCounter.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CalorieCounter.Pages.Users
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public UserListViewModel UserListVM { get; set; }

        public async Task<IActionResult> OnGet(int productPage=1, string searchEmail=null, string searchName=null, string searchWeight=null)
        {
            UserListVM = new UserListViewModel()
            {
                ApplicationUserList = await _db.ApplicationUser.ToListAsync()
            };

            StringBuilder param = new StringBuilder();
            param.Append("/Users?productPage=:");
            param.Append("$searchName=");
            if(searchName!=null)
            {
                param.Append(searchName);
            }
            param.Append("searchEmail=");
            if (searchName != null)
            {
                param.Append(searchEmail);
            }
            param.Append("searchWeight=");
            if (searchName != null)
            {
                param.Append(searchWeight);
            }

            if(searchEmail!=null)
            {
                UserListVM.ApplicationUserList = await _db.ApplicationUser.Where(u => u.Email.ToLower().Contains(searchEmail.ToLower())).ToListAsync();
            }
            else
            {
                if (searchName != null)
                {
                    UserListVM.ApplicationUserList = await _db.ApplicationUser.Where(u => u.Name.ToLower().Contains(searchName.ToLower())).ToListAsync();
                }
                else
                {
                    if (searchWeight != null)
                    {
                        UserListVM.ApplicationUserList = await _db.ApplicationUser.Where(u => u.Weight.ToLower().Contains(searchWeight.ToLower())).ToListAsync();
                    }
                }
            }

            var count = UserListVM.ApplicationUserList.Count;

            UserListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = 2,
                TotalItems = count,
                UrlParam = param.ToString()
            };

            UserListVM.ApplicationUserList = UserListVM.ApplicationUserList.OrderBy(p => p.Email)
                .Skip((productPage - 1) * 2)
                .Take(2).ToList();

            return Page();
        }
    }
}