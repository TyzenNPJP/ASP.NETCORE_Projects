using DNCP10_Services;

namespace DNCP10_ServiceContracts
{
    public interface IWeather
    {
        public int get_city_code();
        public string get_name();
        public DateTime get_date_time();
        public float get_temperature();
        public void set_all(int city_code, string get_name, DateTime date_time, float temperature);
    }
}
