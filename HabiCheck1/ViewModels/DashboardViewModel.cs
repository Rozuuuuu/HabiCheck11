using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabiCheck.Models;
using HabiCheck.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
namespace HabiCheck.ViewModels;

public partial class DashboardViewModel : BaseViewModel
{
    private readonly IWeatherService _weatherService;
    private readonly DatabaseService _dbService;

    [ObservableProperty] private WeatherInfo _weather = new();
    [ObservableProperty] private string _hulasLabel = "Pawisin Profile";
    [ObservableProperty] private string _hulasAdvice = string.Empty;

    public ObservableCollection<ScanRecord> RecentScans { get; } = new();

    public DashboardViewModel(IWeatherService weatherService, DatabaseService dbService)
    {
        _weatherService = weatherService;
        _dbService = dbService;
    }

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsBusy = true;
        try
        {
            Weather = await _weatherService.GetWeatherAsync("Consolacion, Cebu");

            var hulasLevel = Preferences.Get("hulas_level", "pawisin");
            (HulasLabel, HulasAdvice) = hulasLevel switch
            {
                "chill" => ("Chill Lang Profile",
                              "You stay cool naturally! Cotton or linen blends work great for you."),
                "normal" => ("Normal Lang Profile",
                              "Breathable cotton or bamboo blends are your best friend."),
                _ => ("Pawisin Profile",
                              "Sa 32°C ng Cebu, stick to 100% linen or cotton. Iwasan ang polyester!")
            };

            var scans = await _dbService.GetScansAsync();
            RecentScans.Clear();
            foreach (var s in scans.Take(5))
                RecentScans.Add(s);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task StartScanAsync()
        => await Shell.Current.GoToAsync(nameof(Views.ScannerPage));

    [RelayCommand]
    private async Task GoToOnboardingAsync()
        => await Shell.Current.GoToAsync(nameof(Views.OnboardingPage));
}