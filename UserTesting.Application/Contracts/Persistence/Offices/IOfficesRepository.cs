using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Persistence.Base;
using UserTesting.Domain.Entities.Offices;

namespace UserTesting.Application.Contracts.Persistence.Offices
{
    public interface IOfficesRepository : IAsyncRepository<Office>
    {
    }
}
