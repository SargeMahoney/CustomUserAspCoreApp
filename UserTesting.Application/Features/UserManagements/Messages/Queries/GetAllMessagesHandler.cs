using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Persistence.Messages;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Messages;

namespace UserTesting.Application.Features.UserManagements.Messages.Queries
{
    public class GetAllMessagesHandler : IRequestHandler<GetAllMessagesQuery, DataResult<IEnumerable<Message>>>
    {
        private readonly IMessagesRepository _messagesRepositor;

        public GetAllMessagesHandler(IMessagesRepository messagesRepositor)
        {
            this._messagesRepositor = messagesRepositor;
        }
        public async Task<DataResult<IEnumerable<Message>>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            var result = await _messagesRepositor.ListAllAsync();
            if (result.Success)
            {
                return new DataResult<IEnumerable<Message>>(result.GetData().OrderByDescending(x => x.Date));
            }
            else
            {
                return new DataResult<IEnumerable<Message>>(success: false);
            }
        }
    }
}
