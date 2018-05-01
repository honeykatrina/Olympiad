using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class Instructor
    {
        public int InstructorID { get; set; }
        public string InstructorName { get; set; }
        public string InstructorSurname { get; set; }
        public string InstructorPatronymic { get; set; }
        public string InstructorTitle { get; set; }
        public string InstructorDegree { get; set; }
        public string InstructorPosition { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}