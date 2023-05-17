using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using postIT.Views;
using postIT.Models;

namespace postIT.ViewModels;

public partial class RegistrationPageViewModel : ObservableObject
{
	public RegistrationPageViewModel()
	{
        RegisterCommand = new AsyncRelayCommand(goToHomePage);
    }

    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private string confirmPassword;

    public IAsyncRelayCommand RegisterCommand;

    [RelayCommand]
    private async Task goToHomePage()
    {
        // If fields not empty
        if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword))
        {
            if (Password != ConfirmPassword)
            {
                // Error
                await Shell.Current.DisplayAlert("Error", "Passwords Do Not Match", "OK");
            }
            else
            {
                // If username doesn't exist
                if (!LoginModel.Instance.Users.ContainsKey(Email))
                {
                    LoginModel.Instance.Users.Add(Email, Password);
                    await Shell.Current.DisplayAlert("Success", "User Created", "OK");
                    // Redirect home page
                    await Shell.Current.GoToAsync(nameof(HomePage));
                }
                else
                {
                    // Error
                    await Shell.Current.DisplayAlert("Error", "Username already taken", "OK");
                }
            }
        }
        else
        {
            // Fill in fields required
            await Shell.Current.DisplayAlert("Error", "Please enter your email and password.", "OK");
        }
    }
}

