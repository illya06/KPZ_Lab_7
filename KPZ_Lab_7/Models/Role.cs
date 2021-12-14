using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_Lab_7.Models
{
    public partial class Role
    {
        public Role()
        {
            Employees = new HashSet<Employee>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public decimal? RoleWage { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
