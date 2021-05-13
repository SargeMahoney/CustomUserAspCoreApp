using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Offices;

namespace UserTesting.Application.Features.UserManagements.Offices.Queries.GetAll
{
    public class GetAllOfficesQuery : IRequest<DataResult<IEnumerable<Office>>>
    {
    }
}
