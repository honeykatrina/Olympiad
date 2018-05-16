using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Olympiad.Models
{
    public class TeamViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID команды")]
        public int TeamID { get; set; }
        [Required]
        [Display(Name = "Название команды")]
        public string TeamName { get; set; }
    }
}