using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string ClientId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}