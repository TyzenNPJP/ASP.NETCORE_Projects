using DNCP10_ServiceContracts;

namespace DNCP10_Services
{
    public class AllWeather : IAllWeather
    {
        public Weather w1;
        public Weather w2;
        public Weather w3;

        public List<Weather> list_weathers;

        public AllWeather()
        {
            w1.set_all(100, "London", new DateTime(2024, 1, 27, 23, 0, 0), 9);
            w2.set_all(101, "Sydney", new DateTime(2024, 1, 28, 10, 0, 0), 32);
            w3.set_all(102, "Tokyo", new DateTime(2024, 1, 28, 8, 0, 0), 20);

            list_weathers = new List<Weather>() { w1, w2, w3 };
        }
        
        public List<Weather> get_list_weathers()
        {
            return list_weathers;
        }
    }
}
