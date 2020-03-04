using DealsMo.Shared.DTOs;
using DealsMo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealsMo.Client.Repository
{
    public interface IDealRepository
    {
        Task<int> CreateDeal(Deal Deal);
        Task DeleteDeal(int Id);
        Task<DealDetailsDTO> GetDealDetailsDTO(int id);
        Task<IndexPageDTO> GetIndexPageDTO();
        Task<DealUpdateDTO> GetDealForUpdate(int id);
        Task<PaginatedResponse<List<Deal>>> GetDealsFiltered(FilterDealsDTO filterDealsDTO);
        Task UpdateDeal(Deal Deal);
    }
}
