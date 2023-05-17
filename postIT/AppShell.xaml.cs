using postIT.Views;
namespace postIT;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
		Routing.RegisterRoute(nameof(JournalPage), typeof(JournalPage));
        Routing.RegisterRoute(nameof(FullJournalPage), typeof(FullJournalPage));
        Routing.RegisterRoute(nameof(TasksPage), typeof(TasksPage));
        Routing.RegisterRoute(nameof(NotesPage), typeof(NotesPage));
        Routing.RegisterRoute(nameof(FullNotesPage), typeof(FullNotesPage));
		Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
	}
}

