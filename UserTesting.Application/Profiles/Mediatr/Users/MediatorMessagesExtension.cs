using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Features.UserManagements.Messages.Command.AddMessage;
using UserTesting.Application.Features.UserManagements.Messages.Queries;
using UserTesting.Domain.Entities.Messages;

namespace MediatR
{
    public class MediatorMessagesExtension
    {
        private readonly IMapper _mapper;

        public MediatorMessagesExtension(IMapper mapper)
        {
            this._mapper = mapper;
        }

 

        public GetAllMessagesQuery GetAll()
        {
            return new GetAllMessagesQuery();
        }

        public AddMessageCommand Add(Message message)
        {
            var command = _mapper.Map<AddMessageCommand>(message);
            return command;
        }
    }
}
