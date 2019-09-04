using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabDeskApplication.Models
{
    [Table("SetupResult")]
    public class SetupResult
    {
        [Key]
        [Display(Name = "Serial #")]
        public int ResultID { get; set; }

        [Display(Name = "Result's Name")]
        public string ResultName { get; set; }
        public virtual List<TestValues> TestValues { get; set; }
    }
}