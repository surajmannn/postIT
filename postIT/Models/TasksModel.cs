using System;
using System.Collections.Generic;

namespace postIT.Models;

public class TasksModel
{
    // Implementing the Tasks Dictionary in Singleton Pattern
    // Prevents multiple instances being created throughout the program

    private static readonly TasksModel instance = new TasksModel();
    private readonly IDictionary<string, DateTime> items = new Dictionary<string, DateTime>();

    private TasksModel()
    {
    }

    public static TasksModel Instance
    {
        get
        {
            return instance;
        }
    }

    public IDictionary<string, DateTime> Items
    {
        get
        {
            return items;
        }
    }
}

