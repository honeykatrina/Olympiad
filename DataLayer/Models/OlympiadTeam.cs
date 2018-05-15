﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class OlympiadTeam
    {
        public int OlympiadTeamID { get; set; }
        public int OlympiadID { get; set; }
        public int TeamID { get; set; }
        public int TeamPlace { get; set; }
        public int InstructorID { get; set; }

        public virtual Team Team { get; set; }
        public virtual Olympiad Olympiad { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}