using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Olympiad.Models
{
    public class StudentViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Id студента")]
        public int StudentID { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string StudentName { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string StudentSurname { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string StudentPatronymic { get; set; }
        [Required]
        [Display(Name = "Курс")]
        [Range(1, 6, ErrorMessage = "Недопустимый курс")]
        public int Course { get; set; }
        [Required]
        [Display(Name = "Группа")]
        public string Group { get; set; }
        [Required]
        [Display(Name = "Специальность")]
        public string Specialty { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentViewModel Department { get; set; }
    }
}