using DealsMo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealsMo.Client.Repository
{
    public interface IDealCategoryRepository
    {
        Task CreateDealCategory(DealCategory DealCategory);
        Task<DealCategory> GetDealCategory(int Id);
        Task<List<DealCategory>> GetDealCategories();
        Task UpdateDealCategory(DealCategory DealCategory);
        Task DeleteDealCategory(int Id);
    }
}
