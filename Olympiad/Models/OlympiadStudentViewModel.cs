using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Olympiad.Models
{
    public class OlympiadStudentViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID олимпиады")]
        public int OlympiadID { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID студента")]
        public int StudentID { get; set; }
        [Required]
        [Display(Name = "Занятое место")]
        public int StudentPlace { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID преподавателя")]
        public int InstructorID { get; set; }
    }
}