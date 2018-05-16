using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicLayer.Models
{
    public class OlympiadTeamDTO
    {
        public int OlympiadTeamID { get; set; }
        public int OlympiadID { get; set; }
        public int TeamID { get; set; }
        public int TeamPlace { get; set; }
        public int InstructorID { get; set; }
        public Prize Prize { get; set; }

        public OlympiadDTO Olympiad { get; set; }
        public TeamDTO Team { get; set; }
        public InstructorDTO Instructor { get; set; }
    }
}