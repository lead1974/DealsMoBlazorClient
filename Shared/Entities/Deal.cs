using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealsMo.Shared.Entities
{
    public class Deal
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Price { get; set; }
        public bool IsDMProduct { get; set; }
        public bool IsCoupon { get; set; }
        public string CouponCode { get; set; }

        public string DealDomain { get; set; }
        public string Status { get; set; }
        public string DealTrailer { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string ImageURL { get; set; }

        public int Likes { get; set; }
        public int DisLikes { get; set; }
        public int Views { get; set; }
        public bool IsPopular { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedTS { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedTS { get; set; }
        public List<DealsCategories> DealsCategories { get; set; } = new List<DealsCategories>();
        public string TitleBrief
        {
            get
            {
                if (string.IsNullOrEmpty(Title))
                {
                    return null;
                }

                if (Title.Length > 60)
                {
                    return Title.Substring(0, 60) + "...";
                }
                else
                {
                    return Title;
                }
            }
        }
    }
}
