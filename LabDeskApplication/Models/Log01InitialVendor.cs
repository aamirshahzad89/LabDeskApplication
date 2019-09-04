using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabDeskApplication.Models
{
    [Table("LogInitialVendor")]
    public class Log01InitialVendor
    {
        /*
         * Custom Lab ID to be typed in as in the following format. LAB-M-0001
         */
        [Key]
        [Display(Name = "Lab-Serial")]
        public string LabID { get; set; }     

        [Display(Name = "Form Rec.Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime FormDate { get; set; }

        [Display(Name="Composition")]
        public string Composition { get; set; }

        [Display(Name = "Vendor Name")]
        public int VendorID { get; set; }
        public virtual SetupVendor SetupVendor { get; set; }
    }
}