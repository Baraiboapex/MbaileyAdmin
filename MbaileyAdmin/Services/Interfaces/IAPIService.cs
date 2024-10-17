
using MbaileyAdmin.Services.APIServices;

namespace MbaileyAdmin.Services.Interfaces
{
    internal interface IAPIService
    {
        public ServiceResponse BuildResponse(
            bool success, 
            string message, 
            Dictionary<string, object>? data = null
        );
    }
}
