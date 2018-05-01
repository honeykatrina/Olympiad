using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class Olympiad
    {
        public int OlympiadID { get; set; }
        public string OlympiadName { get; set; }
        public string OlympiadLevel { get; set; }
        public DateTime OlympiadStartDate { get; set; }
        public DateTime OlympiadEndDate{ get; set; }
        public string OlympiadDirection { get; set; }
        public string OlympiadType { get; set; }
        public int UniversityID { get; set; }

        public virtual University University { get; set; }
        public virtual ICollection<OlympiadStudent> Students { get; set; }
        public virtual ICollection<OlympiadTeam> Teams { get; set; }
    }
}