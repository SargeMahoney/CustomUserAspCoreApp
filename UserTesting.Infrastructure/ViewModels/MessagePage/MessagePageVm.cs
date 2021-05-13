using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Infrastructure.ViewModels.MessagesPage;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Offices;
using UserTesting.Domain.Entities.Users;
using UserTesting.Domain.Models.Messages;

namespace UserTesting.Infrastructure.ViewModels.MessagePage
{
    public class MessagePageVm : IMessagesPage
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private bool isLoaded;

        public List<Office> Offices { get;  set; }
        public List<ApplicationUser> Users { get;  set; }

        public MessageSetup MessageSetup { get; set; }

        public MessagePageVm(IMediator mediator, IMapper mapper)
        {    
            this._mediator = mediator;
            this._mapper = mapper;
            this.isLoaded = false;
            Offices = new List<Office>();
            Users = new List<ApplicationUser>();
            MessageSetup = new MessageSetup();
        }
        public async Task<BaseResult> SendMessage()
        {
            foreach (var user in Users)
            {
                await SaveMessageForEachUser(user);
            }

           await _mediator.Send(_mediator.Notifications().SendNotificationAboutMessage(MessageSetup));

            MessageSetup = new MessageSetup();
            return new BaseResult();
        }

        private async Task SaveMessageForEachUser(ApplicationUser user)
        {
            if (MessageSetup.OfficesId.Contains(user.OfficeId))
            {
                var newMessage = new UserTesting.Domain.Entities.Messages.Message()
                {
                    UserName = user.UserName,
                    Date = DateTime.Now,
                    IsReaded = false,
                    MessageBody = MessageSetup.MessageBody,
                    Title = MessageSetup.Title
                };
                await this._mediator.Send(this._mediator.Messages(this._mapper).Add(newMessage));
            }
        }

        public async Task<BaseResult> LoadData()
        {
            if (this.isLoaded)
            {
                return new BaseResult();
            }
            var OfficesResult = await this._mediator.Send(this._mediator.Offices().GetAll());
            if (OfficesResult.Success)
            {
                Offices = OfficesResult.GetData().ToList();
            }

            Users = (await this._mediator.Send(this._mediator.Users().GetAll())).ToList();
            this.isLoaded = true;
            return new BaseResult();
        }


    }
}
