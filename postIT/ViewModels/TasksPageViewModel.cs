using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using postIT.Models;

namespace postIT.ViewModels;

public partial class TasksPageViewModel : ObservableObject
{

    [ObservableProperty]
    ObservableCollection<string> tasks;

    [ObservableProperty]
    DateTime selectedDate = DateTime.Today;

    [ObservableProperty]
    string text;

    [ObservableProperty]
    public bool check;

    [ObservableProperty]
    int daysLeft;

    public TasksPageViewModel()
	{
        Tasks = new ObservableCollection<string>();
    }

    [RelayCommand]
	void Add()
	{
		// Add task
		if (string.IsNullOrWhiteSpace(Text))
		{
			return;
		}
        Tasks.Add(Text);
		TasksModel.Instance.Items.Add(Text, SelectedDate);
        DaysLeft = GetDaysLeft(Text);
        Text = string.Empty;
		SelectedDate = DateTime.Today;

    }

	[RelayCommand]
	void Delete(string task)
	{
		// Delete task
		if(Tasks.Contains(task))
		{
			Tasks.Remove(task);
			TasksModel.Instance.Items.Remove(task);
		}
    }

	// Calculate Days until task is due
    public int GetDaysLeft(string task)
    {
        DateTime taskDate = TasksModel.Instance.Items[task];
		int days = (taskDate - DateTime.Today).Days;
		return days;
    }
}