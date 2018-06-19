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
        [Display(Name = "Олимпиада")]
        public int OlympiadID { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Команда")]
        public int TeamID { get; set; }
        [Required]
        [Display(Name = "Занятое место")]
        public int TeamPlace { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Преподаватель")]
        public int InstructorID { get; set; }
        [Display(Name = "Награда")]
        public Prize Prize { get; set; }

        public OlympiadViewModel Olympiad { get; set; }
        public TeamViewModel Team { get; set; }
        public InstructorViewModel Instructor { get; set; }
    }
}