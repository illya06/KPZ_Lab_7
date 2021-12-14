using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_Lab_7.Models
{
    public partial class Order
    {
        public Order()
        {
            Deliveries = new HashSet<Delivery>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int OdererId { get; set; }
        public int CustomerId { get; set; }
        public int? OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? PayPrice { get; set; }
        public int? RegionId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
