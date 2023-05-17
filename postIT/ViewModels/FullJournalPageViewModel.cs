using System;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using postIT.Models;

namespace postIT.ViewModels
{
    [QueryProperty("Text", "Journal")]

    public partial class FullJournalPageViewModel : ObservableObject
	{
        [ObservableProperty]
        string text;

        [ObservableProperty]
        string fullJournal;

        public FullJournalPageViewModel()
        {
        }

        partial void OnTextChanged(string value)
        {
            // bypass for retrieving query property on construction
            FullJournal = check();
        }

        public string check()
        {
            // Check the text (from query property) is not null (Title of journal)
            if (!string.IsNullOrEmpty(Text))
            {
                // If exists display current journal entry in journal page
                if (JournalModel.Instance.Journal.ContainsKey(Text))
                {
                    FullJournal = JournalModel.Instance.Journal[Text];
                }
            }
            else
            {
                // Start blank journal page if does not exist
                FullJournal = string.Empty;
            }
            // return FullJournal value
            return FullJournal;
        }

        public void Add(string journal)
        {
            // Add journal entry text to dictionary

            // Check if entry is null
            if (string.IsNullOrWhiteSpace(journal))
            {
                return;
            }
            if (JournalModel.Instance.Journal.ContainsKey(Text))
            {
                // update new text to dict entry
                JournalModel.Instance.Journal[Text] = journal;
            }
            else
            {
                // Add entry to dict
                JournalModel.Instance.Journal.Add(Text, journal);
            }
        }
    }
}

