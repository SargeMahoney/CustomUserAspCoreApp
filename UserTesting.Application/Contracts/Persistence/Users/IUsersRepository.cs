using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Persistence.Base;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Users;

namespace UserTesting.Application.Contracts.Persistence.Users
{
    public interface  IUsersRepository : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>
    {
        bool CheckIfOffice(string userName, string officeName);

       Task<DataResult<IEnumerable<ApplicationUser>>> GetUsers();
    }
}
