using System;
using System.Collections.Generic;

namespace postIT.Models;

public class NotesModel
{
    // Implementing the Notes Dictionary in Singleton Pattern
    // Prevents multiple instances being created throughout the program

    private static readonly NotesModel instance = new NotesModel();
    private readonly IDictionary<string, string> notes = new Dictionary<string, string>();

    private NotesModel()
    {
    }

    public static NotesModel Instance
    {
        get
        {
            return instance;
        }
    }

    public IDictionary<string, string> Notes
    {
        get
        {
            return notes;
        }
    }
}

