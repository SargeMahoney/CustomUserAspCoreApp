using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Messages;

namespace UserTesting.Application.Features.UserManagements.Messages.Command.AddMessage
{
    public class AddMessageCommand : IRequest<DataResult<Message>>
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public string MessageBody { get; set; }
        public DateTime Date { get; set; }
    }
}
