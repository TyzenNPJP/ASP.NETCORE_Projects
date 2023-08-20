namespace Student_Management_System.Models
{
    public class JsonResponse<T>
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
