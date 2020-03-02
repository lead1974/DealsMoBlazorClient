using DealsMo.Shared.Entities;
using System.Collections.Generic;

namespace DealsMo.Client.Helpers
{
    public interface IRepository
    {
        List<Deal> GetDeals();
    }
}
