using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks.Dataflow;

namespace Student_Management_System.View_Model
{
    public class StudentRegistrationViewModel
    {
        public StudentRegistrationViewModel() 
        {
            GroupData = new List<SelectListItem>();
            LevelData = new List<SelectListItem>();
            CourseData = new List<SelectListItem>();
        }

        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public int LevelId { get; set; }
        public string? LevelName { get; set; }
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        // SelectListItem for being able to select from drop down list in HTML
        public List<SelectListItem> GroupData { get; set; }
        public List<SelectListItem> LevelData { get; set; }
        public List<SelectListItem> CourseData { get; set; }
    }
}
