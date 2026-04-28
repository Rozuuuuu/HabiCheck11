using HabiCheck.Models;
using System.Threading.Tasks;

namespace HabiCheck.Services;

/// <summary>
/// Mock weather service. Replace with real OpenWeatherMap API call:
/// GET https://api.openweathermap.org/data/2.5/weather
///     ?q=Consolacion,PH&appid=YOUR_API_KEY&units=metric
/// </summary>
public class WeatherService : IWeatherService
{
    public async Task<WeatherInfo> GetWeatherAsync(string location)
    {
        await Task.Delay(400); // simulate network
        return new WeatherInfo
        {
            Location = location,
            Temperature = 32,
            FeelsLike = 37,
            Humidity = 85,
            WindSpeed = 12,
            Condition = "Sunny"
        };
    }
}