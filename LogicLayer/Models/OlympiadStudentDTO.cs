﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicLayer.Models
{
    public class OlympiadStudentDTO
    {
        public int OlympiadID { get; set; }
        public int StudentID { get; set; }
        public int StudentPlace { get; set; }
        public int InstructorID { get; set; }
    }
}