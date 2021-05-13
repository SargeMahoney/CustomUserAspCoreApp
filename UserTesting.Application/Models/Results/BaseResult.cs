using System.Collections.Generic;

namespace UserTesting.Application.Models.Results
{
    public class BaseResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }



        public BaseResult()
        {
            Success = true;       
        }

   
        public BaseResult(string message = null)
        {
            Success = true;
            Message = message;
        }

        public BaseResult( bool success,string message = null)
        {
            Success = success;
            Message = string.Empty;
        }

    
    }
}
