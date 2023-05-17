using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using postIT.Views;

namespace postIT.ViewModels;

public partial class JournalPageViewModel : ObservableObject
{
    public JournalPageViewModel()
    {
        Items = new ObservableCollection<string>();
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;

    [RelayCommand]
    void Add()
    {
        // Add task
        if (string.IsNullOrWhiteSpace(Text))
        {
            return;
        }

        Items.Add(Text);
        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string journal)
    {
        // Delete task
        if (Items.Contains(journal))
        {
            Items.Remove(journal);
        }
    }

    [RelayCommand]
    async Task Tap(string journal)
    {
        await Shell.Current.GoToAsync($"{nameof(FullJournalPage)}?Journal={journal}");
    }
}
