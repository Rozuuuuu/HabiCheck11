namespace HabiCheck.Models;

public class WeatherInfo
{
    public string Location { get; set; } = "Consolacion, Cebu";
    public double Temperature { get; set; } = 32;
    public double FeelsLike { get; set; } = 37;
    public int Humidity { get; set; } = 85;
    public double WindSpeed { get; set; } = 12;
    public string Condition { get; set; } = "Sunny";
    public string HumidityLabel => Humidity >= 80 ? "High Humidity" :
                                   Humidity >= 60 ? "Moderate Humidity" : "Low Humidity";
    public string FabricAdvice => Humidity >= 80
        ? "Wear breathable natural fabrics today!"
        : "Any breathable fabric works fine today.";
}