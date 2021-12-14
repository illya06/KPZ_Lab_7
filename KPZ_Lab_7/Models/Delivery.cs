using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_Lab_7.Models
{
    public partial class Delivery
    {
        public int DeliveryId { get; set; }
        public int? DeliveryStatus { get; set; }
        public int? DeliveryByEmployee { get; set; }
        public int? OrderId { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public virtual Employee DeliveryByEmployeeNavigation { get; set; }
        public virtual Order Order { get; set; }
    }
}
