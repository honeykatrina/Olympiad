using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Olympiad.Models
{
    public class OlympiadTeamViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID записи")]
        public int OlympiadTeamID { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID олимпиады")]
        public int OlympiadID { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID команды")]
        public int TeamID { get; set; }
        [Required]
        [Display(Name = "Занятое место")]
        public int TeamPlace { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID преподавателя")]
        public int InstructorID { get; set; }
    }
}