using postIT.ViewModels;
namespace postIT.Views;

public partial class TasksPage : ContentPage
{
	public TasksPage(TasksPageViewModel ViewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel;
	}

    void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var viewModel = (BindingContext as ViewModels.TasksPageViewModel);
        viewModel.Check = e.Value;
    }
}
