using DealsMo.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealsMo.Server
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DealsCategories>().HasKey(x => new { x.DealId, x.CategoryId });

            //var userAdminId = "df4d3070-5e26-4f78-bdd6-f9bb12f55a40";

            //var hasher = new PasswordHasher<IdentityUser>();

            //var userAdmin = new IdentityUser()
            //{
            //    Id = userAdminId,
            //    Email = "felipe@hotmail.com",
            //    UserName = "felipe@hotmail.com",
            //    NormalizedEmail = "felipe@hotmail.com",
            //    NormalizedUserName = "felipe@hotmail.com",
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "aA123456!")
            //};

            //modelBuilder.Entity<IdentityUser>().HasData(userAdmin);

            //modelBuilder.Entity<IdentityUserClaim<string>>()
            //    .HasData(new IdentityUserClaim<string>() { 
            //        Id = 1,
            //        ClaimType = ClaimTypes.Role,
            //        ClaimValue = "Admin",
            //        UserId = userAdminId
            //    }); 

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealsCategories> DealsCategories { get; set; }
        public DbSet<DealRating> DealRating { get; set; }
    }
}
