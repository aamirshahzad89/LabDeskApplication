using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabDeskApplication.Models
{
    [Table("TestApproach")]
    public class TestApproach
    {
        [Key]
        [Display(Name="Sr #")]
        public int TestApproachID { get; set; }
        
        [Display(Name = "Test's Name")]
        public string TestName { get; set; }

        [Display(Name = "Test Standard")]
        public string TestStandard { get; set; }

        [Display(Name = "Appr-1")]
        public string TestApproachName01 { get; set; }

        [Display(Name = "Appr-2")]
        public string TestApproachName02 { get; set; }

        [Display(Name = "Appr-3")]
        public string TestApproachName03 { get; set; }

        [Display(Name = "Appr-4")]
        public string TestApproachName04 { get; set; }

        [Display(Name = "Appr-5")]
        public string TestApproachName05 { get; set; }

        [Display(Name = "Requirements")]
        public string Remarks { get; set; }
    }
}