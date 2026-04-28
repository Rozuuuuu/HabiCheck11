using HabiCheck.Models;
using System.Threading.Tasks;

namespace HabiCheck.Services;

public interface IWeatherService
{
    Task<WeatherInfo> GetWeatherAsync(string location);
}