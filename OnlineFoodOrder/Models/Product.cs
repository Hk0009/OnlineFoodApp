using System;
using System.Collections.Generic;

namespace OnlineFoodOrder.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? Date { get; set; }

        public virtual FoodCategory? Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
