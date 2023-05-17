using postIT.ViewModels;

namespace postIT.Views;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage(RegistrationPageViewModel ViewModel)
	{
		InitializeComponent();
        BindingContext = ViewModel;
    }
}
