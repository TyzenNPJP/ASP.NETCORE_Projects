using System.Threading.Tasks.Dataflow;
using Student_Management_System.Models;

namespace Student_Management_System.View_Model
{
    public class AttendanceViewModel
    {
        public AttendanceViewModel() {
            GroupData = new List<Group>();
            CourseData = new List<Course_1>();
            LevelData = new List<Level>();
        }

        public List<Models.Group> GroupData { get; set; }
        public List<Models.Course_1> CourseData { get; set; }
        public List<Models.Level> LevelData { get; set; }

        public DateTime Date { get; set; }

        public int Id { get; set; }
        public int CourseId { get; set; }
        public int LevelId { get; set; }
        public int GroupId { get; set; }
    }
}
