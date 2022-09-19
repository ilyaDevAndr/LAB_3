using LAB_3.ViewModels;

namespace LAB_3;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new FoodViewModel();
    }
}

