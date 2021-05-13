using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Persistence.Offices;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Offices;

namespace UserTesting.Application.Features.UserManagements.Offices.Queries.GetAll
{
    public class GetAllOfficesHandler : IRequestHandler<GetAllOfficesQuery, DataResult<IEnumerable<Office>>>
    {
        private readonly IOfficesRepository _officeRepository;

        public GetAllOfficesHandler(IOfficesRepository officeRepository)
        {
            this._officeRepository = officeRepository;
        }
        public async Task<DataResult<IEnumerable<Office>>> Handle(GetAllOfficesQuery request, CancellationToken cancellationToken)
        {
            var officeList = await _officeRepository.ListAllAsync();
            if (officeList.Success)
            {
                return new DataResult<IEnumerable<Office>>(officeList.GetData());
            }

            return new DataResult<IEnumerable<Office>>(success: false);
        }
    }


    
}
