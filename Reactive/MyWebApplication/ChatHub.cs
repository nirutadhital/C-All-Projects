using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace MyWebApplication
{
    // public class ChatHub : Hub
    // {
        // public void Send(string name, string message)
        // {
        //     // Call the broadcastMessage method to update clients.
        //     Clients.All.broadcastMessage(name, message);
        // }
    // }

    public class ChatHub : Hub
    {
        public async Task Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("broadcastMessage", name, message);
        }
    }
}