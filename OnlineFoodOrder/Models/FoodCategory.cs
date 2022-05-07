using System;
using System.Collections.Generic;

namespace OnlineFoodOrder.Models
{
    public partial class FoodCategory
    {
        public FoodCategory()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public int? RestaurantId { get; set; }

        public virtual RestaurantInfo? Restaurant { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
