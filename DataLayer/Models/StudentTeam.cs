using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class StudentTeam
    {
        public int StudentTeamID { get; set; }
        public int StudentID { get; set; }
        public int TeamID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Team Team { get; set; }
    }
}