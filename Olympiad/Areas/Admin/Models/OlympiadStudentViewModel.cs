﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Olympiad.Areas.Admin.Models
{
    public class OlympiadStudentViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID записи")]
        public int OlympiadStudentID { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Олимпиада")]
        public int OlympiadID { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Студент")]
        public int StudentID { get; set; }
        [Required]
        [Display(Name = "Занятое место")]
        public int StudentPlace { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Преподаватель")]
        public int InstructorID { get; set; }
        [Display(Name = "Награда")]
        public Prize Prize { get; set; }

        public OlympiadViewModel Olympiad { get; set; }
        public StudentViewModel Student { get; set; }
        public InstructorViewModel Instructor { get; set; }
    }
}