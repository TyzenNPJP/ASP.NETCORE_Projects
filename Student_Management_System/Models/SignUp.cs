namespace Student_Management_System.Models
{
    public class SignUp
    {
        public int ID { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public int? phonenum { get; set; }
        public DateTime createdDate { get; set; }
    }
}
