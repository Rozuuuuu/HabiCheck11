using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using Microsoft.Maui.Storage; 
using Microsoft.Maui.Controls; 

namespace HabiCheck.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty] private string _email = string.Empty;
    [ObservableProperty] private string _password = string.Empty;
    [ObservableProperty] private bool _showPassword;
    [ObservableProperty] private string _errorMessage = string.Empty;

    [RelayCommand]
    private async Task LoginAsync()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Please enter your email and password.";
            return;
        }

        IsBusy = true;
        ErrorMessage = string.Empty;

        try
        {
            await Task.Delay(1000); // replace with real auth call

            // Store login state
            Preferences.Set("is_logged_in", true);

            // Navigate to dashboard, clear back stack
            await Shell.Current.GoToAsync($"//{nameof(Views.DashboardPage)}",
                animate: true);
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Login failed: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task ContinueAsGuestAsync()
    {
        Preferences.Set("is_guest", true);
        await Shell.Current.GoToAsync($"//{nameof(Views.DashboardPage)}",
            animate: true);
    }

    [RelayCommand]
    private void TogglePasswordVisibility()
        => ShowPassword = !ShowPassword;
}   