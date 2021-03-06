﻿using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentPatronymic { get; set; }
        public int Course { get; set; }
        public string Group { get; set; }
        public string Specialty { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<OlympiadStudent> Olympiads { get; set; }
        public virtual ICollection<StudentTeam> Teams { get; set; }
    }
}