using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public void Add(OrderAddVM model)
        {
            if (ModelState.IsValid)
            {
                _orderService.Add(model);
            }
        }

        [HttpGet("getOrders")]
        public object GetOrders()
        {
               return  _orderService.GetOrders();
        }

    }
}
