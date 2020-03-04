using DealsMo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealsMo.Server.Helpers
{
    public class DMSeedDataService
    {
        private readonly ApplicationDbContext context;
        public DMSeedDataService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void EnsureSeedData()
        {
            //await SeedAdminUsers();
            SeedDealCategories();
            //await SeedStores();
            //await SeedDeals();
            //await SeedCoupons();
            //await SeedAffiliateSites();

        }

        private void SeedDealCategories()
        {
            int dealCategoriesCount = context.DealCategories.Count();

            if (dealCategoriesCount == 0)
            {
                var dCategories = new DealCategory[] {
                new DealCategory
                {

                    Name = "Autos",
                    ShortName = "Autos",
                    Status = Const.StatusActive.ToString(),
                    Seq = 1,
                    FAIcon="fas fa-car",
                    IsPrivateCategory = false,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Entertainment",
                    ShortName = "Entertainment",
                    Status = Const.StatusActive.ToString(),
                    Seq = 2,
                    FAIcon="fas fa-theater-masks",
                    IsPrivateCategory = false,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Books & Magazines",
                    ShortName = "Books",
                    Seq = 2,
                    FAIcon="fas fa-book-reader",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Children",
                    ShortName = "Children",
                    Seq = 2,
                    FAIcon="fas fa-child",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Clothing & Accessories",
                    ShortName = "Apparel",
                    Seq = 2,
                    FAIcon="fas fa-luggage-cart",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Computers & Accessories",
                    ShortName = "Computers",
                    Seq = 2,
                    FAIcon ="fas fa-laptop-code",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Education",
                    ShortName = "Education",
                    Seq = 2,
                    FAIcon="fas fa-user-graduate",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Credit Cards",
                    ShortName = "Finance",
                    Seq = 2,
                    FAIcon="fas fa-piggy-bank",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Flowers & Gifts",
                    ShortName = "Flowers",
                    Seq = 2,
                    FAIcon="fas fa-gift",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Freebies",
                    ShortName = "Freebies",
                    Seq = 2,
                    FAIcon="fas fa-hand-holding-usd",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Grocery",
                    ShortName = "Grocery",
                    Seq = 2,
                    FAIcon="fas fa-shopping-cart",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },

                new DealCategory
                {

                    Name = "Health & Beauty",
                    ShortName = "Health",
                    Seq = 2,
                    FAIcon="fas fa-medkit",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Home & Home Improvement",
                    ShortName = "Home",
                    Seq = 2,
                    FAIcon="fas fa-home",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Jewerly & Watches",
                    ShortName = "Jewerly",
                    Seq = 2,
                    FAIcon="far fa-clock",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },

                new DealCategory
                {

                    Name = "Office & School Supplies",
                    ShortName = "Office",
                    Seq = 2,
                    FAIcon="far fa-clipboard",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Pets",
                    ShortName = "Pets",
                    Seq = 2,
                    FAIcon="fas fa-paw",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Phones & Accessories",
                    ShortName = "Phones",
                    Seq = 2,
                    FAIcon="fas fa-phone",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Restaurants",
                    ShortName = "Restaurants",
                    Seq = 2,
                    FAIcon="fas fa-wine-bottle",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Services",
                    ShortName = "Services",
                    Seq = 2,
                    FAIcon="fas fa-shipping-fast",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {
                    Name = "Shoes",
                    ShortName = "Shoes",
                    Seq = 2,
                    FAIcon="fas fa-shoe-prints",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Sports & Outdoors",
                    ShortName = "Sports",
                    Seq = 2,
                    FAIcon="fas fa-football-ball",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Tech & Electronics",
                    ShortName = "Electronics",
                    Seq = 2,
                    FAIcon="fab fa-android",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Toys",
                    ShortName = "Toys",
                    Seq = 2,
                    FAIcon="fas fa-dove",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Travel and Vacations",
                    ShortName = "Travel",
                    Seq = 2,
                    FAIcon="fas fa-umbrella-beach",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Other",
                    ShortName = "Other",
                    Seq = 999,
                    FAIcon="fas fa-yin-yang",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "General Store",
                    ShortName = "General",
                    Seq = 888,
                    FAIcon="fas fa-shopping-cart",
                    IsPrivateCategory = false,
                    Status = Const.StatusActive.ToString(),
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
            };

                context.AddRange(dCategories);
                context.SaveChanges();
            }
        }

    }
}
