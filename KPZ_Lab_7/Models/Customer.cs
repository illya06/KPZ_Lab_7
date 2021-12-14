using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace KPZ_Lab_7.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        [EmailAddress]
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime? FirstPurchaseDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
