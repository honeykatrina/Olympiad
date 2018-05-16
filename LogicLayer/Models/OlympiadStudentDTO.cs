using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Models;

namespace LogicLayer.Models
{
    public class OlympiadStudentDTO
    {
        public int OlympiadStudentID { get; set; }
        public int OlympiadID { get; set; }
        public int StudentID { get; set; }
        public int StudentPlace { get; set; }
        public int InstructorID { get; set; }
        public Prize Prize { get; set; }

        public OlympiadDTO Olympiad { get; set; }
        public StudentDTO Student { get; set; }
        public InstructorDTO Instructor { get; set; }
    }
}