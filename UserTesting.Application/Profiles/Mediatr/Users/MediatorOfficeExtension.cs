using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Features.UserManagements.Offices.Queries.GetAll;

namespace MediatR
{
    public class MediatorOfficeExtension
    {

        public MediatorOfficeExtension()
        {

        }

        public GetAllOfficesQuery GetAll()
        {
            return new GetAllOfficesQuery();
        }
    }
}
