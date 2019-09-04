using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabDeskApplication.Models
{
    [Table("SetupVendor")]
    public class SetupVendor
    {
        [Key]
        [Display(Name = "Serial #")]
        public int VendorID { get; set; }
        [Column(Order = 1)]
        [Display(Name = "Vendor's Name")]
        public string VendorName { get; set; }
        public virtual List<Log01InitialVendor> LogInitialVendor { get; set; }
    }
}