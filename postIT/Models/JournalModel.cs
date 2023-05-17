using System;
using System.Collections.Generic;

namespace postIT.Models;

public class JournalModel
{
    // Implementing the Journal Dictionary in Singleton Pattern
    // Prevents multiple instances being created throughout the program

    private static readonly JournalModel instance = new JournalModel();
    private readonly IDictionary<string, string> journal = new Dictionary<string, string>();

    private JournalModel()
    {
    }

    public static JournalModel Instance
    {
        get
        {
            return instance;
        }
    }

    public IDictionary<string, string> Journal
    {
        get
        {
            return journal;
        }
    }
}