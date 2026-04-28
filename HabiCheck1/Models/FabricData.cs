using System.Collections.Generic;

namespace HabiCheck.Models;

public class FabricData
{
    public string Name { get; set; } = string.Empty;
    public string Grade { get; set; } = string.Empty;
    public string FiberType { get; set; } = string.Empty;
    public int Breathability { get; set; }
    public int Sustainability { get; set; }
    public string Description { get; set; } = string.Empty;
    public string PersonalMessage { get; set; } = string.Empty;
    public string? ClimateAlert { get; set; }
    public List<string> WashTips { get; set; } = new();
    public string ResaleValue { get; set; } = string.Empty;
    public string UpcyclingIdea { get; set; } = string.Empty;
    public bool IsSuccess => Grade.StartsWith("A");
}