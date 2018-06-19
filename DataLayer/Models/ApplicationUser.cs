using Microsoft.AspNet.Identity.EntityFramework;

namespace DataLayer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}