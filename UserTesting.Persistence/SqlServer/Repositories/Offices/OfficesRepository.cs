using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Persistence.Offices;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Offices;
using UserTesting.Persistence.Configurations;
using UserTesting.Persistence.SqlServer._base;

namespace UserTesting.Persistence.SqlServer.Repositories.Offices
{
    public class OfficesRepository : SqlDbBaseRepository, IOfficesRepository
    {
        private readonly IMapper _mapper;

        public OfficesRepository(IMapper mapper,IDatabaseSettings dbConfig) : base(dbConfig)
        {
            this._mapper = mapper;
        }

        public Task<DataResult<Office>> AddAsync(Office entity)
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<Office>> DeleteAsync(Office entity)
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<Office>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResult<IEnumerable<Office>>> ListAllAsync()
        {
            using var _connection = Connection;
            var sql = "SELECT * " +
                       "FROM UserOffices ";




            var myOffices = await _connection.QueryAsync<OfficeDto>(sql);
            

            return new DataResult<IEnumerable<Office>>(_mapper.Map<IEnumerable<Office>>(myOffices));
        }

        public Task<DataResult<Office>> UpdateAsync(Office entity)
        {
            throw new NotImplementedException();
        }
    }
}
