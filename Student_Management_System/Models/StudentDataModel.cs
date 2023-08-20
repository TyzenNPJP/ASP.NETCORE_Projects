namespace Student_Management_System.Models
{
    public class StudentDataModel
    {
        public StudentDataModel() { 
            StudentDetailData = new List<StudentDetailModel> { };
        }

        public string? Name { get; set; }
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int LevelId { get; set; }
        public int GroupId { get; set; }
        public int Sn { get; set; }
        public int Status { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }

        public List<StudentDetailModel> StudentDetailData { get; set; }
    }
}
