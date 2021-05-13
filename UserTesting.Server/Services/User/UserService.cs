using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Infrastructure.Messages;
using UserTesting.Application.Contracts.Persistence.Users;
using UserTesting.Domain.Entities.Users;

namespace UserTesting.Server.Services.User
{
    public class UserService : IUserService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IUsersRepository _usersRepository;
   
        public  bool IsLogged = false;

        public UserService(AuthenticationStateProvider AuthenticationStateProvider, IUsersRepository usersRepository)
        {
            this._authenticationStateProvider = AuthenticationStateProvider;
            this._usersRepository = usersRepository;         
        }

        public ApplicationUser CurrentUser { get; set; } = new ApplicationUser();


        public event EventHandler Event_UserLoggedIn;

        public int MessageNotReaded
        {
            get
            {
                return CurrentUser.Messages.Where(x => x.IsReaded == false).Count();
            }
        
        }

        public async Task RefreshUser()
        {
            try
            {
                var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
                var User = authState.User;

                if (User.Identity.IsAuthenticated)
                {

                    CurrentUser = await _usersRepository.FindByNameAsync(User.Identity.Name, new System.Threading.CancellationToken());
                    CurrentUser.IsAuthenticated = User.Identity.IsAuthenticated;
                    Event_UserLoggedIn.Raise(this, new EventArgs());

                }
                else
                {
                    CurrentUser = new ApplicationUser();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
   
        }



        public async Task LoggedIn()
        {
            try
            {
                if (IsLogged)
                {
                    return;
                }
                var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
                var User = authState.User;

                if (User.Identity.IsAuthenticated)
                {

                    CurrentUser = await _usersRepository.FindByNameAsync(User.Identity.Name, new System.Threading.CancellationToken());
                    CurrentUser.IsAuthenticated = User.Identity.IsAuthenticated;
                    Event_UserLoggedIn.Raise(this, new EventArgs());

                }
                else
                {
                    CurrentUser = new ApplicationUser();
                }

                IsLogged = true;
            }
            catch (Exception ex)
            {

           
            }
          
        }


    }
}
