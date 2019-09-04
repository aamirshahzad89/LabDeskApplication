using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabDeskApplication.Models
{
    [Table("SetupProduct")]
    public class SetupProduct
    {
        [Key]
        [Display(Name = "Serial #")]
        public int ProductID { get; set; }

        [Display(Name = "Products's Name")]
        public string ProductName { get; set; }
        public virtual List<Log02InitialArticle> LogInitialArticle { get; set; }
    }
}