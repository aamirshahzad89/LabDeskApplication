using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabDeskApplication.Models
{
    [Table("TestValues")]
    public class TestValues
    {
        [Key]
        [Display(Name = "Sr #")]
        public int TestNameID { get; set; }

        [Display(Name = "Test Performed")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime TestDate { get; set; }

        [Display(Name = "Test Name")]
        public int TestApproachID { get; set; }
        public virtual TestApproach TestApproach { get; set; }

        [Display(Name = "Val-1")]
        public string TestValues01 { get; set; }
        
        [Display(Name = "Val-2")]
        public string TestValues02 { get; set; }
        
        [Display(Name = "Val-3")]
        public string TestValues03 { get; set; }
        
        [Display(Name = "Val-4")]
        public string TestValues04 { get; set; }
        
        [Display(Name = "Val-5")]
        public string TestValues05 { get; set; }

        [Display(Name = "Result")]
        public int ResultID { get; set; }

        public virtual SetupResult SetupResult { get; set; }

        /*
         * Foregin Link From the LogInitialStyle Table
         */
        [Display(Name = "StyId")]
        public int StyleID { get; set; }
        public virtual Log03InitialStyle LogInitialStyle { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }
    }
}