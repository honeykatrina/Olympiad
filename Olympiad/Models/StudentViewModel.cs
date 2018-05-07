﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olympiad.Models
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentPatronymic { get; set; }
        public int Course { get; set; }
        public string Group { get; set; }
        public string Specialty { get; set; }
        public int DepartmentId { get; set; }

        public DepartmentViewModel Department { get; set; }
    }
}