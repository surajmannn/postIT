using postIT.ViewModels;
namespace postIT.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel ViewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel;
	}
}
