using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Olympiad.Models
{
    public class OlympiadViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID олимпиады")]
        public int OlympiadID { get; set; }
        [Required]
        [Display(Name = "Название олимпиады")]
        public string OlympiadName { get; set; }
        [Required]
        [Display(Name = "Уровень")]
        public string OlympiadLevel { get; set; }
        [Required]
        [Display(Name = "Дата начала")]
        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OlympiadStartDate { get; set; }
        [Required]
        [Display(Name = "Дата окончания")]
        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OlympiadEndDate{ get; set; }
        [Required]
        [Display(Name = "Направление")]
        public string OlympiadDirection { get; set; }
        [Required]
        [Display(Name = "Тип")]
        public string OlympiadType { get; set; }
        [Display(Name = "Университет")]
        public int UniversityID { get; set; }

        public UniversityViewModel University { get; set; }
    }
}