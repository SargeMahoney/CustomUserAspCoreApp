using System;
using System.Threading.Tasks;
using UserTesting.Domain.Entities.Users;

namespace UserTesting.Server.Services.User
{
    public interface IUserService
    {
        ApplicationUser CurrentUser { get; set; }

        int MessageNotReaded { get;  }
        Task LoggedIn();

        Task RefreshUser();

        event EventHandler Event_UserLoggedIn;
}
}