using System;
using System.Collections.Generic;
using System.Text;

namespace DealsMo.Shared.Entities
{
    public class DealsCategories
    {
        public int DealId { get; set; }
        public int CategoryId { get; set; }
        public Deal Deal { get; set; }
        public Category Category { get; set; }
    }
}
