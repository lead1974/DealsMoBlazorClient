using DealsMo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DealsMo.Shared.DTOs
{
    public class DealDetailsDTO
    {
        public Deal Deal { get; set; }
        public List<Category> Categories { get; set; }
        public double AverageVote { get; set; }
        public int UserVote { get; set; }
    }
}
