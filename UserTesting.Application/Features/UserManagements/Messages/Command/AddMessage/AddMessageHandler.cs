using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Infrastructure.Messages;
using UserTesting.Application.Contracts.Persistence.Messages;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Messages;

namespace UserTesting.Application.Features.UserManagements.Messages.Command.AddMessage
{
    public class AddMessageHandler : IRequestHandler<AddMessageCommand, DataResult<Message>>
    {
        private readonly IMapper _mapper;
        private readonly IMessagesRepository _messagesRepository;
     

        public AddMessageHandler(IMapper mapper, IMessagesRepository messagesRepository)
        {
            this._mapper = mapper;
            this._messagesRepository = messagesRepository;
      
        }
        public async Task<DataResult<Message>> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            var message = _mapper.Map<Message>(request);
            var resultAddMessage = await _messagesRepository.AddAsync(message);
            if (resultAddMessage.Success)
            {               
                return new DataResult<Message>(resultAddMessage.GetData());
            }
            else
            {
                return new DataResult<Message>(success: false);
            }
        }
    }
}
