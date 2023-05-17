using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using postIT.Views;
using postIT.Models;

namespace postIT.ViewModels;

public partial class LoginPageViewModel : ObservableObject
{
    public LoginPageViewModel()
    {
        LoginCommand = new AsyncRelayCommand(goToHomePage);
        RegisterCommand = new AsyncRelayCommand(RegisterUser);
    }

    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    public IAsyncRelayCommand LoginCommand;

    public IAsyncRelayCommand RegisterCommand;

    [RelayCommand]
    private async Task goToHomePage()
    {
        // If fields not empty
        if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
        {
            // If username exists
            if (LoginModel.Instance.Users.ContainsKey(Email))
            {
                // If user match
                if (LoginModel.Instance.Users[Email] == Password)
                {
                    // Redirect home page
                    await Shell.Current.GoToAsync(nameof(HomePage));
                } else
                {
                    // Password error
                    await Shell.Current.DisplayAlert("Error", "Password Incorrect", "OK");
                }
            } else
            {
                // User not found
                await Shell.Current.DisplayAlert("Error", "User does not exist...", "OK");
            }
        } else
        {
            // Fill in fields required
            await Shell.Current.DisplayAlert("Error", "Please enter your email and password.", "OK");
        }      
    }

    [RelayCommand]
    private async Task RegisterUser()
    {
        await Shell.Current.GoToAsync(nameof(RegistrationPage));
    }
}

