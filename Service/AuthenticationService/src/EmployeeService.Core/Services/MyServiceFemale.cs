using AuthenticationService.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.Core.Services
{
    public class MyServiceFemale : IMyService
    {
        public string Speak()
        {
            return "Toi la con gai";
        }
    }
}
