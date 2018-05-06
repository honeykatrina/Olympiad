using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olympiad.Models
{
    public class OlympiadViewModel
    {
        public int OlympiadID { get; set; }
        public string OlympiadName { get; set; }
        public string OlympiadLevel { get; set; }
        public DateTime OlympiadStartDate { get; set; }
        public DateTime OlympiadEndDate{ get; set; }
        public string OlympiadDirection { get; set; }
        public string OlympiadType { get; set; }
        public int UniversityID { get; set; }
    }
}