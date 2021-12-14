using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_Lab_7.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Deliveries = new HashSet<Delivery>();
            Regions = new HashSet<Region>();
        }

        public int EmployeeId { get; set; }
        public int? EmployeeRole { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }
        public int? EmployeeManagerId { get; set; }
        public int? EmployeeRegion { get; set; }

        public virtual Region EmployeeRegionNavigation { get; set; }
        public virtual Role EmployeeRoleNavigation { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }
}
