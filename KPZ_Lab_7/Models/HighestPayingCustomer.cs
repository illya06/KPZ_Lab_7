using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_Lab_7.Models
{
    public partial class HighestPayingCustomer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal? Bill { get; set; }
    }
}
