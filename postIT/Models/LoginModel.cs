using System;
namespace postIT.Models;

public class LoginModel
{
    // Implementing the User Dictionary in Singleton Pattern
    // Prevents multiple instances being created throughout the program

    private static readonly LoginModel instance = new LoginModel();
    private readonly IDictionary<string, string> users = new Dictionary<string, string>();

    public LoginModel()
    {
        // Base user
        users.Add("Surajmannn", "123");
    }

    public static LoginModel Instance
    {
        get
        {
            return instance;
        }
    }

    public IDictionary<string, string> Users
    {
        get
        {
            return users;
        }
    }
}

