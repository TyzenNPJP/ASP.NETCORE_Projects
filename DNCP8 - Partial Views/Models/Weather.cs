//A weather class whose objects create data for cities

using Microsoft.AspNetCore.Mvc;

namespace DNCP8_PartialViews.Models
{
    public class Weather
    {
        public int city_code { get; set; }
        public string? name { get; set; }
        public DateTime date_time { get; set; }
        public int temperature { get; set; }
    }
}
