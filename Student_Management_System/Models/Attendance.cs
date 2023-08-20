namespace Student_Management_System.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int CourseId { get; set; }
        public int LevelId { get; set; }
        public int GroupId { get; set; }
        
        public IEnumerable<AttendanceDetail>? AttendanceDetails { get; set; }
    }
}
