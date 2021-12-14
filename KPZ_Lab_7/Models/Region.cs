using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_Lab_7.Models
{
    public partial class Region
    {
        public Region()
        {
            Employees = new HashSet<Employee>();
            Orders = new HashSet<Order>();
        }

        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public int? RegionHead { get; set; }
        public int? RegionEmployeeCount { get; set; }

        public virtual Employee RegionHeadNavigation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
