
using MbaileyAdmin.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbaileyAdmin.Services.APIServices
{
    public class BaseAPIService : IAPIService
    {
        protected readonly ServiceResponse _serviceResponse = new ServiceResponse();
        public BaseAPIService()
        { 
               
        }
        public ServiceResponse BuildResponse(bool success, string message, Dictionary<string, object>? data = null)
        {
            _serviceResponse.Success = success;
            _serviceResponse.Message = message;

            if (data != null)
            {
                _serviceResponse.Data = data;
            }

            return _serviceResponse;
        }
    }
}
