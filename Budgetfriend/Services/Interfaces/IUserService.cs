using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budgetfriend.Model;

namespace Budgetfriend.Services.Interfaces
{
    public interface IUserService
    {
        bool Login(User user);
        bool IsLoggedIn { get; }

         string PreferredCurrency { get; }
        string LoggedInUser { get; }
    }
}