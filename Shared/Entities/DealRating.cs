using System;
using System.Collections.Generic;
using System.Text;

namespace DealsMo.Shared.Entities
{
    public class DealRating
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public DateTime RatingDate { get; set; }
        public int DealId { get; set; }
        public Deal Deal { get; set; }
        public string UserId { get; set; }
    }
}
