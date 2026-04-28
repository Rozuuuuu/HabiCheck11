using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Media;

namespace HabiCheck.ViewModels;

public partial class ScannerViewModel : ObservableObject
{
    [RelayCommand]
    private async Task ScanPhotoAsync()
    {
        var photo = await MediaPicker.Default.PickPhotoAsync();
        if (photo != null)
        {
            using System.IO.Stream sourceStream = await photo.OpenReadAsync();
        }
    }

    [RelayCommand]
    private async Task GoBackAsync() =>
        await Shell.Current.GoToAsync("..");
}