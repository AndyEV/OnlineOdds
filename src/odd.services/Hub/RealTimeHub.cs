using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace odd.services
{
    public class RealTimeHub : Hub
    {
        public async Task SendOdds(decimal home, decimal draw, decimal away)
        {
            await Clients.All.SendAsync("Latest Odd", home, draw, away);
        }
    }
}
