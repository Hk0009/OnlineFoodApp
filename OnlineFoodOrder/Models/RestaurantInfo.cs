using System;
using System.Collections.Generic;

namespace OnlineFoodOrder.Models
{
    public partial class RestaurantInfo
    {
        public RestaurantInfo()
        {
            FoodCategories = new HashSet<FoodCategory>();
        }

        public int RestaurantId { get; set; }
        public string? RestaurantName { get; set; }
        public string? Contact { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<FoodCategory> FoodCategories { get; set; }
    }
}
