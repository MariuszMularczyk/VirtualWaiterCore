
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
        public async Task GetDrinks(object drinks)
        {
            await Clients.All.SendAsync("TakeDrinks", drinks);
        }
    }
}
