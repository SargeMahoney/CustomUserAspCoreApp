using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Messages;

namespace UserTesting.Application.Features.UserManagements.Messages.Queries
{
    public class GetAllMessagesQuery : IRequest<DataResult<IEnumerable<Message>>>
    {
    }
}
