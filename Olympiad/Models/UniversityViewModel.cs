using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Olympiad.Models
{
    public class UniversityViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Id университета")]
        public int UniversityID { get; set; }
        [Required]
        [Display(Name = "Университет")]
        public string UniversityName { get; set; }
        [Required]
        [Display(Name = "Город")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Страна")]
        public string Country { get; set; }
    }
}