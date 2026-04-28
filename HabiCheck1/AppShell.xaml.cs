namespace HabiCheck;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register all routes for GoToAsync navigation
        Routing.RegisterRoute(nameof(Views.LoginPage), typeof(Views.LoginPage));
        Routing.RegisterRoute(nameof(Views.DashboardPage), typeof(Views.DashboardPage));
        Routing.RegisterRoute(nameof(Views.OnboardingPage), typeof(Views.OnboardingPage));
        Routing.RegisterRoute(nameof(Views.ScannerPage), typeof(Views.ScannerPage));
        Routing.RegisterRoute(nameof(Views.ResultPage), typeof(Views.ResultPage));
        Routing.RegisterRoute(nameof(Views.ClosetPage), typeof(Views.ClosetPage));
        Routing.RegisterRoute(nameof(Views.EcoMapPage), typeof(Views.EcoMapPage));
    }
}