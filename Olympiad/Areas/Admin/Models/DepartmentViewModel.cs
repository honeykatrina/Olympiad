using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Olympiad.Areas.Admin.Models
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