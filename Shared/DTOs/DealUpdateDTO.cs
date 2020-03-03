using DealsMo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DealsMo.Shared.DTOs
{
    public class DealUpdateDTO
    {
        public Deal Deal { get; set; }
        public List<DealCategory> SelectedCategories { get; set; }
        public List<DealCategory> NotSelectedCategories { get; set; }
    }
}
