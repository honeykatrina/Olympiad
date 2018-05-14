using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Olympiad.Models
{
    public class StudentTeamViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID студента")]
        public int StudentID { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID команды")]
        public int TeamID { get; set; }
    }
}