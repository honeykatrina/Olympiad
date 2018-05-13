using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Olympiad.Models
{
    public class DepartmentViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID кафедры")]
        public int DepartmentID { get; set; }
        [Required]
        [Display(Name = "Кафедра")]
        public string DepartmentName { get; set; }

    }

}