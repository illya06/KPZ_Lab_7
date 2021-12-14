using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_Lab_7.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }

        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeRestrictions { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
