using DealsMo.Client.Helpers;
using DealsMo.Shared.DTOs;
using DealsMo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealsMo.Client.Repository
{
    public class DealRepository : IDealRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/deals";

        public DealRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public Task<DealDetailsDTO> GetDealDetailsDTO(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DealUpdateDTO> GetDealForUpdate(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedResponse<List<Deal>>> GetDealsFiltered(FilterDealsDTO filterDealsDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IndexPageDTO> GetIndexPageDTO()
        {
            throw new NotImplementedException();
        }
        
        public async Task<int> CreateDeal(Deal deal)
        {
            var response = await httpService.Post<Deal, int>(url, deal);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task UpdateDeal(Deal deal)
        {
            var response = await httpService.Put(url, deal);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
        
        public async Task DeleteDeal(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
