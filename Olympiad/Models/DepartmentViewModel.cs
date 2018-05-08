using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olympiad.Models
{
    public class DepartmentViewModel
    {
        public int DepartmentID { get; set; }
        public DepartmentName DepartmentName { get; set; }

    }

    public enum DepartmentName
    {
        first,
        second
    }
}