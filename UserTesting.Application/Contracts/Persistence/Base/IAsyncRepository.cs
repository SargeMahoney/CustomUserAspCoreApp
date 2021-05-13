using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTesting.Application.Models.Results;

namespace UserTesting.Application.Contracts.Persistence.Base
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<DataResult<T>> GetByIdAsync(Guid id);
        Task<DataResult<IEnumerable<T>>> ListAllAsync();
        Task<DataResult<T>> AddAsync(T entity);
        Task<DataResult<T>> UpdateAsync(T entity);
        Task<DataResult<T>> DeleteAsync(T entity);
    }
}
