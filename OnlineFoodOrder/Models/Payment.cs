using System;
using System.Collections.Generic;

namespace OnlineFoodOrder.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public string? Mode { get; set; }
        public int? PersonlId { get; set; }

        public virtual PersonalInfo? Personl { get; set; }
    }
}
