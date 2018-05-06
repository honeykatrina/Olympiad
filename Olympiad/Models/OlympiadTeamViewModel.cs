using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olympiad.Models
{
    public class OlympiadTeamViewModel
    {
        public int OlympiadID { get; set; }
        public int TeamID { get; set; }
        public int TeamPlace { get; set; }
        public int InstructorID { get; set; }
    }
}