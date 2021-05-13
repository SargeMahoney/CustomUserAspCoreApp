using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Users;

namespace UserTesting.Application.Features.UserManagements.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<BaseResult>
    {
   
        public string Password { get; set; }
        public string Name { get; set; }

        public string UserName { get; set; }

        public Guid RoleId { get; set; }
    }
}
