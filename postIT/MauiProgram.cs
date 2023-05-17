using Microsoft.Extensions.Logging;
using postIT.ViewModels;
using postIT.Views;
using postIT.Services;

namespace postIT;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<HomePageViewModel>();

        builder.Services.AddSingleton<JournalPage>();
        builder.Services.AddSingleton<JournalPageViewModel>();

        builder.Services.AddTransient<FullJournalPage>();
        builder.Services.AddTransient<FullJournalPageViewModel>();

        builder.Services.AddSingleton<NotesPage>();
		builder.Services.AddSingleton<NotesPageViewModel>();

        builder.Services.AddTransient<FullNotesPage>();
        builder.Services.AddTransient<FullNotesPageViewModel>();

        builder.Services.AddSingleton<TasksPage>();
        builder.Services.AddSingleton<TasksPageViewModel>();

        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginPageViewModel>();

        builder.Services.AddSingleton<RegistrationPage>();
        builder.Services.AddSingleton<RegistrationPageViewModel>();

        builder.Services.AddSingleton<WeatherService>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

