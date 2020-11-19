using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using VirtualWaiterCore.Application;
using VirtualWaiterCore.Data;
using VirtualWaiterCore.Dictionaries;

namespace VirtualWaiterCore.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("add")]
        public async void Add(OrderAddVM model)
        {

            if (ModelState.IsValid)
            {
                object orders = _orderService.Add(model);
                object drinks = _orderService.GetDrinks();
                HubConnection connection = new HubConnectionBuilder().WithUrl("https://localhost:44379/kitchen/ordersHub").Build();

                await connection.StartAsync();

                await connection.InvokeAsync("GetOrders", orders);
                await connection.InvokeAsync("GetDrinks", drinks);

            }

        }
        [HttpGet("getOrders")]
        public object GetOrders()
        {
            return _orderService.GetOrders();
        }

        [HttpGet("getDrinksOrder")]
        public object GetDrinks()
        {
            return _orderService.GetDrinks();
        }


    }
}
