using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabDeskApplication.Models
{
    [Table("SetupUserInfo")]
    public class SetupUserInfo
    {
        [Key]
        public int UserID { get; set; }
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }
        public virtual List<Log03InitialStyle> LogInitialStyle { get; set; }
    }
}