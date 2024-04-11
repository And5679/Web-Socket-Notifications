
using Microsoft.AspNetCore.SignalR;

namespace Ejercicio.Hubs
{
    public class NotificationHub : Microsoft.AspNetCore.SignalR.Hub
    {
       public async Task SendNotifications(string type,string title,string message) {

            await Clients.All.SendAsync("ReceiveNotification",type,title,message);

        }


    }
}