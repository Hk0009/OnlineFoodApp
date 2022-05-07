using System;
using System.Collections.Generic;

namespace OnlineFoodOrder.Models
{
    public partial class PersonalInfo
    {
        public PersonalInfo()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int PersonlId { get; set; }
        public string? PersonName { get; set; }
        public string? MobileNo { get; set; }
        public string? Contact { get; set; }
        public string? Adress { get; set; }
        public int? Pincode { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
