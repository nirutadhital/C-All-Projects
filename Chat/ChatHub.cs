using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
namespace Signalrdemo
{
    // [Route("/chatHub")]

    public class ChatHub : Hub{
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("Receive Message", user, message);
        }
    }
}