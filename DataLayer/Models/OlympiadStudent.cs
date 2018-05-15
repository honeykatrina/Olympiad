using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class OlympiadStudent
    {
        public int OlympiadStudentID { get; set; }
        public int OlympiadID { get; set; }
        public int StudentID { get; set; }
        public int StudentPlace { get; set; }
        public int InstructorID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Olympiad Olympiad { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}