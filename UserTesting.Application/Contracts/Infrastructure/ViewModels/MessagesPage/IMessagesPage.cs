using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Offices;
using UserTesting.Domain.Entities.Users;
using UserTesting.Domain.Models.Messages;

namespace UserTesting.Application.Contracts.Infrastructure.ViewModels.MessagesPage
{
    public interface IMessagesPage
    {
        List<Office> Offices { get;  }

        List<ApplicationUser> Users { get;  }

        MessageSetup MessageSetup { get; set; }

        Task<BaseResult> SendMessage();

        Task<BaseResult> LoadData();
    }
}
