using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Features.UserManagements.Users.Queries.GetUserList;

namespace UserTesting.Application.Profiles.Mediatr.Users
{
    public class MediatorUsersExtension
    {
        private readonly IMapper _mapper;

        public MediatorUsersExtension(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public MediatorUsersExtension()
        {
           
        }

        public GetUsersQuery GetAll()
        {
            return new GetUsersQuery();
        }

    
    }
}
