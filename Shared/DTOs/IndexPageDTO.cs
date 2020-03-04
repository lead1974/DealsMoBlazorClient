using DealsMo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DealsMo.Shared.DTOs
{
    public class IndexPageDTO
    {
        public List<Deal> PopularDeals { get; set; }
        public List<Deal> UpcomingDeals { get; set; }
    }
}
