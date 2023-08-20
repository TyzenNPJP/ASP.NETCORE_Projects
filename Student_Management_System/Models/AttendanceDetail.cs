namespace Student_Management_System.Models
{
    public class AttendanceDetail
    {
        public int Id { get; set; }
        public int AttendanceId { get; set;}
        public int StudentId { get; set; }
        public byte AbsentPresentStatus { get; set; }

        // Must be teh same name as Id above
        public Attendance? Attendance { get; set; }
    }
}
