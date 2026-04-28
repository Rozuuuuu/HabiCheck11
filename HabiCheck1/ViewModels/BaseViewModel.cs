using CommunityToolkit.Mvvm.ComponentModel;

namespace HabiCheck.ViewModels;

/// All ViewModels inherit from this.
/// IsBusy drives loading spinners. Title sets page titles.
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;

    [ObservableProperty]
    private string _title = string.Empty;

    public bool IsNotBusy => !IsBusy;
}