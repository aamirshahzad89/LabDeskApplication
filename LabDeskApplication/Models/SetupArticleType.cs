using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabDeskApplication.Models
{
    [Table("SetupArticleType")]
    public class SetupArticleType
    {
        [Key]
        [Display(Name = "Serial #")]
        public int ArticleTypeId { get; set; }

        [Display(Name = "Article's Type")]
        public string ArticleType { get; set; }
        public virtual List<Log03InitialStyle> LogInitialStyle { get; set; }
    }
}