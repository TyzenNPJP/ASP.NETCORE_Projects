using DNCP10_Services;

namespace DNCP10_ServiceContracts
{
    public interface IAllWeather
    {
        public List<Weather> get_list_weathers();
    }
}
