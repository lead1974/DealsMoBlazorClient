using DealsMo.Client.Helpers;
using DealsMo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealsMo.Client.Repository
{
    public class DealCategoryRepository : IDealCategoryRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/dealcategories";

        public DealCategoryRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<DealCategory>> GetDealCategories()
        {
            var response = await httpService.Get<List<DealCategory>>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }
        public async Task<DealCategory> GetDealCategory(int Id)
        {
            var response = await httpService.Get<DealCategory>($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task CreateDealCategory(DealCategory dealcategory)
        {
            var response = await httpService.Post(url, dealcategory);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task UpdateDealCategory(DealCategory dealcategory)
        {
            var response = await httpService.Put(url, dealcategory);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeleteDealCategory(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
