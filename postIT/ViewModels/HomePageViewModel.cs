using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using postIT.Views;
using System;
using postIT.Services;

namespace postIT.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    WeatherService weatherService = new WeatherService();

    [ObservableProperty]
    string temperature;

    double temperatureD;

    public HomePageViewModel()
    {
        Task task = LoadWeather();

    }

    [RelayCommand]
    async Task Tap(string page)
    {
        await Shell.Current.GoToAsync(page);
    }

    [RelayCommand]
    async Task LoadWeather()
    {
        try
        {
            temperatureD = await weatherService.GetWeather();
            Temperature = temperatureD + " Degrees";
            OnPropertyChanged();
        }
        catch (Exception ex)
        {
            // handle exception
        }
    }
}
