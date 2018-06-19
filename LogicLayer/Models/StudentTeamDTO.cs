namespace LogicLayer.Models
{
    public class StudentTeamDTO
    {
        public int StudentTeamID { get; set; }
        public int StudentID { get; set; }
        public int TeamID { get; set; }

        public StudentDTO Student { get; set; }
        public TeamDTO Team { get; set; }
    }
}