using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabDeskApplication.Models
{
    [Table("LogInitialStyle")]
    public class Log03InitialStyle
    {
        [Key]
        [Display(Name = "StyId")]
        public int StyleID { get; set; }

        [Display(Name = "Sample Rec.Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime SampleDate { get; set; }
        
        [Display(Name="Sample")]
        public string Sample { get; set; }

        [Display(Name = "Vol")]
        public int Volume { get; set; }

        [Display(Name = "Year")]
        public int Year { get; set; }

        [Display(Name = "Width")]
        public string Width { get; set; }

        [Display(Name = "Colour")]
        public int ColourID { get; set; }
        public virtual SetupColour SetupColour { get; set; }

        [Display(Name = "Article")]
        public int ArticleTypeId { get; set; }
        public virtual SetupArticleType SetupArticleType { get; set; }

        //This Value has been updated to the below mentioned ResultID.
        //public string Remarks { get; set; }
        [Display(Name = "Result")]
        public int ResultID { get; set; }
        public virtual SetupResult SetupResult { get; set; }

        //[Display(Name = "Comments")]
        //public string Comments { get; set; }

        [Display(Name = "Tested By")]
        public int UserID { get; set; }
        public virtual SetupUserInfo SetupUserInfo { get; set; }
        /*
         * Foregin Link From the Log02InitialArticle Table
         */
        [Display(Name = "ArtId #")]
        public int ArticleID { get; set; }
        public virtual Log02InitialArticle LogInitialArticle { get; set; }

        public virtual Log01InitialVendor LogInitialVendor { get; set; }
    }
}