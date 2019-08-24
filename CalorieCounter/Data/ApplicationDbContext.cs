using System;
using System.Collections.Generic;
using System.Text;
using CalorieCounter.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalorieCounter.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FoodType> FoodType { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<DailyFood> DailyFood { get; set; }
        public DbSet<ServiceAddFood> ServiceAddFood { get; set; }
        public DbSet<FoodHeader> FoodHeader { get; set; }
        public DbSet<FoodDetails> Food { get; set; } 
    }
}
