using postIT.ViewModels;
namespace postIT.Views;

public partial class NotesPage : ContentPage
{
	public NotesPage(NotesPageViewModel ViewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel;
	}
}
