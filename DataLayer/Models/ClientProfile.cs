using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class ClientProfile
    {
        [ForeignKey("ApplicationUser")]
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}