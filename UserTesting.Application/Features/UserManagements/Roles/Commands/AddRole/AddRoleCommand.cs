using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Models.Results;

namespace UserTesting.Application.Features.UserManagements.Roles.Commands.AddRole
{
    public class AddRoleCommand : IRequest<BaseResult>
    {

        public string Name { get; set; }
    }
}
