using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbaileyAdmin.Services.APIServices
{
    public class ServiceResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Dictionary<string, object>? Data { get; set; } = null;
    }
}
