using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_Lab_7.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public int? ProfuctType { get; set; }
        public int? SupplierId { get; set; }
        public string ProductName { get; set; }
        public decimal? PrqoductPrice { get; set; }
        public string PrqoductDescription { get; set; }

        public virtual ProductType ProfuctTypeNavigation { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
