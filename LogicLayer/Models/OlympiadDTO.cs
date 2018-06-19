using System;

namespace LogicLayer.Models
{
    public class OlympiadDTO
    {
        public int OlympiadID { get; set; }
        public string OlympiadName { get; set; }
        public string OlympiadLevel { get; set; }
        public DateTime OlympiadStartDate { get; set; }
        public DateTime OlympiadEndDate{ get; set; }
        public string OlympiadDirection { get; set; }
        public string OlympiadType { get; set; }
        public int UniversityID { get; set; }

        public UniversityDTO University { get; set; }
    }
}