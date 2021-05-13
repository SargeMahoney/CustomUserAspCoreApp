using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Contracts.Persistence.Messages;
using UserTesting.Application.Models.Results;
using UserTesting.Domain.Entities.Messages;
using UserTesting.Persistence.Configurations;
using UserTesting.Persistence.SqlServer._base;

namespace UserTesting.Persistence.SqlServer.Repositories.Messages
{
    public class UserMessagesRepository : SqlDbBaseRepository, IMessagesRepository
    {
        private readonly IMapper _mapper;

        public UserMessagesRepository(IDatabaseSettings dbConfig, IMapper mapper) : base(dbConfig)
        {
            this._mapper = mapper;
        }

        public async Task<DataResult<Message>> AddAsync(Message entity)
        {
            try
            {
                using var _connection = Connection;

                var sql = "INSERT INTO dbo.UsersMessages(UserName, Title, MessageBody, Date, IsReaded) OUTPUT INSERTED.Id " +
                    "VALUES (@UserName, @Title, @MessageBody, @Date, @IsReaded)";

                var id = await _connection.QuerySingleAsync<Guid>(sql, new { entity.UserName, entity.Title, entity.MessageBody, entity.Date, entity.IsReaded });

                if (id != Guid.Empty)
                {
                    entity.Id = id;
                    return new DataResult<Message>(entity);
                }
                return new DataResult<Message>(success: false);
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        public Task<DataResult<Message>> DeleteAsync(Message entity)
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<Message>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResult<IEnumerable<Message>>> ListAllAsync()
        {
            using var _connection = Connection;

            var sql = "SELECT * FROM dbo.UsersMessages ";

            var rows = await _connection.QueryAsync<MessageDto>(sql);
            if (rows.Count() > 0)
            {
                var data = _mapper.Map<IEnumerable<Message>>(rows);
                return new DataResult<IEnumerable<Message>>(data);
            }
            else
            {
                return new DataResult<IEnumerable<Message>>(success: false);
            }
        }

        public Task<DataResult<Message>> UpdateAsync(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
