using Microsoft.AspNetCore.SignalR;

namespace SignalRMvcChat
{
    public class ChatHub : Hub
    {
        //public void Send(string name, string message)
        //{
        //    // Call the addNewMessageToPage method to update clients.
        //    //Clients.All.addNewMessageToPage(name, message);

        //}
        public async Task SendMessage(string user, string message)
        {
            // Your code logic
            await Clients.All.SendAsync("addNewMessageToPage", user, message); // This matches the method name in JavaScript
        }
    }
}
