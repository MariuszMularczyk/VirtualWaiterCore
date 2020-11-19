
using Autofac;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace VirtualWaiterCore.WebAPI
{

    public class OrderHub : Hub
    {

        public async Task GetOrders(object orders)
        {
            await Clients.All.SendAsync("TakeOrders", orders);
        }
        public async Task GetDrinks(object orders)
        {
            await Clients.All.SendAsync("TakeDrinks", orders);
        }
        public async Task GetWaiter(object table)
        {
            await Clients.All.SendAsync("SendWaiter", table);
        }
    }
}
