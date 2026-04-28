using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabiCheck.Models;
using HabiCheck.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Storage;
using System.Threading.Tasks;

namespace HabiCheck.ViewModels;

[QueryProperty(nameof(ResultType), "resultType")]
public partial class ResultViewModel : BaseViewModel
{
    private readonly IFabricAnalyzerService _analyzer;

    [ObservableProperty] private string _resultType = "success";
    [ObservableProperty] private FabricData _fabricData = new();
    [ObservableProperty] private bool _isSuccess;
    [ObservableProperty] private Color _gradeColor = Colors.Green;
    [ObservableProperty] private string _gradientStart = "#7BA05B";
    [ObservableProperty] private string _gradientEnd = "#5F7A61";

    public ResultViewModel(IFabricAnalyzerService analyzer)
        => _analyzer = analyzer;

    partial void OnResultTypeChanged(string value)
    {
        IsSuccess = value == "success";

        var hulasLevel = Preferences.Get("hulas_level", "pawisin");

        FabricData = IsSuccess
            ? new FabricData
            {
                Name = "Premium Linen",
                Grade = "A+",
                FiberType = "100% Natural Linen",
                Breathability = 95,
                Sustainability = 90,
                PersonalMessage = hulasLevel == "pawisin"
                      ? "Perfect! Super breathable ito para sa Cebu humidity. Goodbye sticky feeling!"
                      : "Great choice! This natural fabric will keep you comfortable all day.",
                WashTips = new() { "Cold water wash only", "Hang dry in shade", "Iron while damp" },
                ResaleValue = "₱450 – ₱850",
                UpcyclingIdea = "Reusable market bags or decorative pillow covers."
            }
            : new FabricData
            {
                Name = "Polyester Blend",
                Grade = "F-",
                FiberType = "85% Polyester, 15% Rayon",
                Breathability = 25,
                Sustainability = 15,
                PersonalMessage = hulasLevel == "pawisin"
                      ? "Babala! Plastic bag ang feel nito sa init. Mataas ang risk ng amoy-araw!"
                      : "Not ideal for our tropical climate. Poor airflow and moisture-wicking.",
                ClimateAlert = "Sa 32°C ng Cebu, itrap ng fabric na ito ang sweat at magiging amoy-araw ka bago mag-tanghali.",
                WashTips = new() { "Wash separately", "Use fabric softener", "Low heat or air dry" },
                ResaleValue = "₱80 – ₱150",
                UpcyclingIdea = "\"Basahan\" – cleaning cloth for floors or windows."
            };

        GradeColor = IsSuccess ? Color.FromArgb("#7BA05B") : Color.FromArgb("#D84545");
        GradientStart = IsSuccess ? "#7BA05B" : "#D84545";
        GradientEnd = IsSuccess ? "#5F7A61" : "#C97B63";
    }

    [RelayCommand]
    private async Task ScanAnotherAsync()
        => await Shell.Current.GoToAsync($"../{nameof(Views.ScannerPage)}");

    [RelayCommand]
    private async Task GoHomeAsync()
        => await Shell.Current.GoToAsync($"//{nameof(Views.DashboardPage)}");
}