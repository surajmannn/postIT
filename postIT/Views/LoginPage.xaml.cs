using postIT.ViewModels;

namespace postIT.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel ViewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel;
	}
}
