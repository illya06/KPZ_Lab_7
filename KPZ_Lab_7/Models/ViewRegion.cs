using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_Lab_7.Models
{
    public partial class ViewRegion
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public int? RegionHead { get; set; }
        public int? RegionEmployeeCount { get; set; }
    }
}
