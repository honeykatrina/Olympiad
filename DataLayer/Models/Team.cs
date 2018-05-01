using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }

        public virtual ICollection<StudentTeam> Students { get; set; }
        public virtual ICollection<OlympiadTeam> Olympiads{ get; set; }
    }
}