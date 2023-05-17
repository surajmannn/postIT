using System;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using postIT.Models;

namespace postIT.ViewModels;

// Retrieve title of Note from NotesPageViewModel
[QueryProperty("Text", "Note")]

public partial class FullNotesPageViewModel : ObservableObject
{
    [ObservableProperty]
    string text;

    [ObservableProperty]
    string fullNote;

    public FullNotesPageViewModel()
    {
    }

    partial void OnTextChanged(string value)
    {
        // bypass for retrieving query property on construction
        FullNote = check();
    }

    public string check()
    {
        // Check the text (from query property) is not null (Title of note)
        if (!string.IsNullOrEmpty(Text))
        {
            // If exists display current note in note page
            if (NotesModel.Instance.Notes.ContainsKey(Text))
            {
                FullNote = NotesModel.Instance.Notes[Text];
            }
        }
        else
        {
            // Start blank note if does not exist
            FullNote = string.Empty;
        }
        // return FullNote value
        return FullNote;
    }

    public void Add(string note)
    {
        // Add Notes page text to dictionary

        // Check if entry is null
        if (string.IsNullOrWhiteSpace(note))
        {
            return;
        }
        if (NotesModel.Instance.Notes.ContainsKey(Text))
        {
            // update new text to dict entry
            NotesModel.Instance.Notes[Text] = note;
        }
        else
        {
            // Add entry to dict
            NotesModel.Instance.Notes.Add(Text, note);
        }
    }
}