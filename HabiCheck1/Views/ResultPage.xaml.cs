using HabiCheck.ViewModels;

namespace HabiCheck.Views;

public partial class ResultPage : ContentPage
{
    public ResultPage()
    {
        InitializeComponent();
    }

    public ResultPage(ResultViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}