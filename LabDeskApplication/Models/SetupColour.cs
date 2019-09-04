using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabDeskApplication.Models
{
    [Table("SetupColor")]
    public class SetupColour
    {
        [Key]
        [Display(Name = "Serial #")]
        public int ColourID { get; set; }

        [Display(Name = "Colour's Name")]
        public string ColourName { get; set; }
        public virtual List<Log01InitialVendor> LogInitialVendor { get; set; }
    }
}