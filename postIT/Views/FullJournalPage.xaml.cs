using postIT.ViewModels;
namespace postIT.Views;

public partial class FullJournalPage : ContentPage
{
	public FullJournalPage(FullJournalPageViewModel ViewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel;
	}

    void OnEditorTextChanged(object sender, TextChangedEventArgs e)
    {
        // When text from the Editor xaml is changed, update dict
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        var viewModel = (BindingContext as ViewModels.FullJournalPageViewModel);
        viewModel.Add(newText);
    }

    void OnEditorCompleted(object sender, EventArgs e)
    {
        // When text from editor is complete, update or add to dictgit
        string journal = ((Editor)sender).Text;
        var viewModel = (BindingContext as ViewModels.FullJournalPageViewModel);
        viewModel.Add(journal);
    }
}
