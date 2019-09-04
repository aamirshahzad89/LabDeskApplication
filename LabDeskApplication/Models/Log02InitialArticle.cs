using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabDeskApplication.Models
{
    [Table("LogInitialArticle")]
    public class Log02InitialArticle
    {
        [Key]
        [Display(Name = "ArtId")]
        public int ArticleID { get; set; }

        //public DateTime SampleDate { get; set; }

        [Display(Name = "Style Code")]
        public string StyleCode { get; set; }

        [Display(Name = "Seq")]
        public char Sequence { get; set; }

        [Display(Name = "Product")]
        public int ProductID { get; set; }
        public virtual SetupProduct SetupProduct { get; set; }
        
        /*
         * Foregin Link From the Log01InitialVendor Table
         */
        [Display(Name = "LabId")]
        public string LabID { get; set; }
        public virtual Log01InitialVendor LogInitialVendor { get; set; }

    }
}