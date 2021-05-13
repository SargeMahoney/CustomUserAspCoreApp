using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Persistence.Users;
using UserTesting.Domain.Entities.Users;

namespace UserTesting.Application.Features.UserManagements.Users.Queries.GetUserList
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<ApplicationUser>>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUsersHandler(IUsersRepository usersRepository)
        {
            this._usersRepository = usersRepository;
        }
        public async Task<IEnumerable<ApplicationUser>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var usersResult = await _usersRepository.GetUsers();
            if (usersResult.Success)
            {
                return usersResult.GetData();
            }
            else
            {
                return new List<ApplicationUser>();
            }
        }
    }
}
