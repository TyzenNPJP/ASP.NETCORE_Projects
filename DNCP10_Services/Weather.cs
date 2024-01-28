using DNCP10_ServiceContracts;

namespace DNCP10_Services
{
    public class Weather : IWeather
    {
        private int city_code;
        private string? name;
        private DateTime date_time;
        private float temperature;

        public int get_city_code()
        {
            return city_code;
        }

        public string get_name()
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            else
            {
                return name;
            }
        }

        public DateTime get_date_time()
        {
            return date_time;
        }

        public float get_temperature()
        {
            return temperature;
        }

        public void set_all(int city_code, string name, DateTime date_time, float temperature)
        {
            this.city_code = city_code;
            this.name = name;
            this.date_time = date_time;
            this.temperature = temperature;
        }
    }
}
