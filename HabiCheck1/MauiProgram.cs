using CommunityToolkit.Maui;
using HabiCheck.Services;
using HabiCheck.ViewModels;
using HabiCheck.Views;
using HabiCheck1;
using Microsoft.Extensions.Logging;

namespace HabiCheck1;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemiBold");
                fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
            });

        // ── Services (Singleton = lives entire app lifetime) ──────────────
        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddSingleton<IFabricAnalyzerService, FabricAnalyzerService>();
        builder.Services.AddSingleton<IWeatherService, WeatherService>();

        // ── ViewModels (Transient = fresh instance per navigation) ─────────
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<DashboardViewModel>();
        builder.Services.AddTransient<OnboardingViewModel>();
        builder.Services.AddTransient<ScannerViewModel>();
        builder.Services.AddTransient<ResultViewModel>();

        // ── Pages ──────────────────────────────────────────────────────────
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<OnboardingPage>();
        builder.Services.AddTransient<ScannerPage>();
        builder.Services.AddTransient<ResultPage>();
        builder.Services.AddTransient<ClosetPage>();
        builder.Services.AddTransient<EcoMapPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}