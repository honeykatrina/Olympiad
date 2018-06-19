using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Olympiad.Models
{
    public class InstructorViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID преподавателя")]
        public int InstructorID { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string InstructorName { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string InstructorSurname { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string InstructorPatronymic { get; set; }
        [Required]
        [Display(Name = "Ученое звание")]
        public string InstructorTitle { get; set; }
        [Required]
        [Display(Name = "Ученая степень")]
        public string InstructorDegree { get; set; }
        [Required]
        [Display(Name = "Должность")]
        public string InstructorPosition { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentViewModel Department { get; set; }
    }
}