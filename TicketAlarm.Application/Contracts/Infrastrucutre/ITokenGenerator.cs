using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAlarm.Application.Contracts.Infrastrucutre
{
    public interface ITokenGenerator
    {
        string GenerateToken(string role, string username);
    }
}
