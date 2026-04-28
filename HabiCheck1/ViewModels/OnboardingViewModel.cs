using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using Microsoft.Maui.Controls;

namespace HabiCheck.ViewModels;

public partial class OnboardingViewModel : BaseViewModel
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ContinueCommand))]
    private string? _selectedHulas;

    private bool CanContinue() => !string.IsNullOrWhiteSpace(SelectedHulas);

    [RelayCommand(CanExecute = nameof(CanContinue))]
    private async Task ContinueAsync()
    {
        if (string.IsNullOrWhiteSpace(SelectedHulas)) return;

        Preferences.Set("hulas_level", SelectedHulas);

        await Shell.Current.GoToAsync($"///{nameof(Views.ScannerPage)}");
    }

    [RelayCommand]
    private void SelectHulas(string level)
    {
        SelectedHulas = level;
    }
}