using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Domain.Entities.Users;

namespace UserTesting.Application.Features.UserManagements.Users.Queries.GetUserList
{
    public class GetUsersQuery : IRequest<IEnumerable<ApplicationUser>>
    {
    }
}
