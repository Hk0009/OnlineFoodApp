using System;
using System.Collections.Generic;

namespace OnlineFoodOrder.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }
        public DateTime? Date { get; set; }
        public int? PersonlId { get; set; }

        public virtual PersonalInfo? Personl { get; set; }
        public virtual Product? Product { get; set; }
    }
}
