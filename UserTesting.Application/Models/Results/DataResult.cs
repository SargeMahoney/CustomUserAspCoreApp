using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTesting.Application.Models.Results
{
    public class DataResult<T> : BaseResult where T : class
    {

        protected T Data { get; set; }

        public DataResult(T data)
        {
            Data = data;
            Success = true;
        }
        public DataResult(bool success)
        {
         
            Success = success;
        }

        public T GetData()
        {
            return Data;
        }

        public void SetData(T data)
        {
            Data = data;
        }
    }
}
