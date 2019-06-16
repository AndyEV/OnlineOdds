﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace odd.services
{
    public class OddPublisher : Hub
    {
        public async Task BroadcastData()
        {
            await Clients.All.SendAsync("BroadcastData");
        }
    }
}
