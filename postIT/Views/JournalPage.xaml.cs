using postIT.ViewModels;
namespace postIT.Views;

public partial class JournalPage : ContentPage
{
	public JournalPage(JournalPageViewModel ViewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel;
	}
}
