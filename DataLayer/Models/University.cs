using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class University
    {
        public int UniversityID { get; set; }
        public string UniversityName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Olympiad> Olympiads { get; set; }
    }
}