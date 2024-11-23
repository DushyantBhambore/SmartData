using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRImplementation.SignaleR
{
    public class ChatHub : Hub
    {
        public async Task MessageSent(string message, string userName)
        {
            await this.Clients.All.SendAsync("messageRecieved", message, userName);
        }
    }
}
