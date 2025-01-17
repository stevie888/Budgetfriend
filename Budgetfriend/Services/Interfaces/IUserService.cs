using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budgetfriend.Model;

namespace Budgetfriend.Services.Interfaces
{
    /// <summary>
    /// Interface for managing user-related operations and state
    /// This service handles user authentication and user preferences
    /// </summary>
    public interface IUserService
    {
        // Attempts to authenticate a user and returns true if successful
        bool Login(User user);

        // Indicates whether a user is currently authenticated
        bool IsLoggedIn { get; }

        // Gets the user's preferred currency format (e.g., USD, EUR, GBP)
        string PreferredCurrency { get; }

        // Gets the username/identifier of the currently logged-in user
        string LoggedInUser { get; }
    }
}