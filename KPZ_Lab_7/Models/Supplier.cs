using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace KPZ_Lab_7.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupplierId { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierName { get; set; }
        [Required]
        public string SupplierPhone { get; set; }
        [EmailAddress]
        public string SupplierEmail { get; set; }
        public string ContactName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
