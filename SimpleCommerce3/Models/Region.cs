using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce3.Models
{
    public class Region// Bölge
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ParentRegionId { get; set; }
        [ForeignKey("ParentRegionId")]
        public Region ParentRegion { get; set; }
        public RegionType RegionType { get; set; }
    }
}
