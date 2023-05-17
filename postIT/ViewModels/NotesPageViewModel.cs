using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using postIT.Views;
using postIT.Models;

namespace postIT.ViewModels;

public partial class NotesPageViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;

    public NotesPageViewModel()
    {
        Items = new ObservableCollection<string>();
    }

    [RelayCommand]
    void Add()
    {
        // Add Note entry
        if (string.IsNullOrWhiteSpace(Text))
        {
            return;
        }
        Items.Add(Text);
        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string note)
    {
        // Delete note entry
        if (Items.Contains(note))
        {
            Items.Remove(note);
            NotesModel.Instance.Notes.Remove(note);  // Remove from Notes dictionary
        }
    }

    [RelayCommand]
    async Task Tap(string note)
    {
        // Send current note to FullNotesPage sending Name of note as query property
        await Shell.Current.GoToAsync($"{nameof(FullNotesPage)}?Note={note}");
    }

}