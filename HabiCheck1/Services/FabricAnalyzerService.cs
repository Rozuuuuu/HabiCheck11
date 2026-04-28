using HabiCheck.Models;
namespace HabiCheck.Services;

/// <summary>
/// Mock analyzer. Replace AnalyzeAsync with a real ML.NET model
/// or a REST API call (e.g., Azure Custom Vision) in production.
/// </summary>
public class FabricAnalyzerService : IFabricAnalyzerService
{
    private static readonly Random _rng = new();

    public async Task<FabricData> AnalyzeAsync(Stream imageStream, string hulasLevel)
    {
        // Simulate network / model inference delay
        await Task.Delay(2500);

        bool isNatural = _rng.NextDouble() > 0.5;

        return isNatural
            ? BuildNaturalFabric(hulasLevel)
            : BuildSyntheticFabric(hulasLevel);
    }

    private static FabricData BuildNaturalFabric(string hulasLevel) => new()
    {
        Name = "Premium Linen",
        Grade = "A+",
        FiberType = "100% Natural Linen",
        Breathability = 95,
        Sustainability = 90,
        Description = "High-grade natural fiber with excellent breathability.",
        PersonalMessage = hulasLevel == "pawisin"
            ? "Perfect para sa iyo! Super breathable ito, angkop sa 85% humidity ng Cebu."
            : "Great choice! This natural fabric keeps you comfortable all day.",
        WashTips = new() { "Cold water wash only", "Hang dry in shade", "Iron while slightly damp" },
        ResaleValue = "₱450 – ₱850",
        UpcyclingIdea = "Can be turned into reusable market bags or decorative pillow covers."
    };

    private static FabricData BuildSyntheticFabric(string hulasLevel) => new()
    {
        Name = "Polyester Blend",
        Grade = "F-",
        FiberType = "85% Polyester, 15% Rayon",
        Breathability = 25,
        Sustainability = 15,
        Description = "Synthetic fabric with poor breathability.",
        PersonalMessage = hulasLevel == "pawisin"
            ? "Warning! Parang plastic bag ang feel nito sa init. Mataas ang risk ng amoy-araw!"
            : "Not ideal for our tropical climate. Limited airflow and moisture-wicking.",
        ClimateAlert = "Sa 32°C heat ng Cebu, itrap ng fabric na ito ang pawis at magiging amoy-araw ka bago mag-tanghali.",
        WashTips = new() { "Wash separately", "Use fabric softener", "Low heat or air dry only" },
        ResaleValue = "₱80 – ₱150",
        UpcyclingIdea = "Perfect bilang \"Basahan\" – cleaning cloth for floors or windows."
    };
}