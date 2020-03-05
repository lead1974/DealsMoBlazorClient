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

        public async Task<DealDetailsDTO> GetDealDetailsDTO(int id)
        {
            return await httpService.GetHelper<DealDetailsDTO>($"{url}/{id}");
        }

        public async Task<DealUpdateDTO> GetDealForUpdate(int id)
        {
            return await httpService.GetHelper<DealUpdateDTO>($"{url}/update/{id}");
        }

        public async Task<PaginatedResponse<List<Deal>>> GetDealsFiltered(FilterDealsDTO filterDealsDTO)
        {
            var responseHTTP = await httpService.Post<FilterDealsDTO, List<Deal>>($"{url}/filter", filterDealsDTO);
            var totalAmountPages = int.Parse(responseHTTP.HttpResponseMessage.Headers.GetValues("totalAmountPages").FirstOrDefault());
            var paginatedResponse = new PaginatedResponse<List<Deal>>()
            {
                Response = responseHTTP.Response,
                TotalAmountPages = totalAmountPages
            };

            return paginatedResponse;
        }

        public async Task<IndexPageDTO> GetIndexPageDTO()
        {
            return await httpService.GetHelper<IndexPageDTO>(url);
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
