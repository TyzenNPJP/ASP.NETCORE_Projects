namespace DNCP6_RazorViews.Models
{
    public class CityWeather
    {
        public string? City_Unique_Code { get; set; }
        public string? City_Name { get; set; }
        public DateTime? Date_Time {get; set;}
        public int? TemperatureF { get; set;}
    }
}
