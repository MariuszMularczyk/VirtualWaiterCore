using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VirtualWaiterCore.Application;
using VirtualWaiterCore.Data;

namespace VirtualWaiterCore.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppetizerController : ControllerBase
    {

        private readonly IAppetizerService _appetizerService;

        public AppetizerController(IAppetizerService appetizerService)
        {
            _appetizerService = appetizerService;
        }

        [HttpPost("add")]
        public void Add(AppetizerAddVM model)
        {
            if (ModelState.IsValid)
            {
                _appetizerService.Add(model);
            }
        }

        [HttpGet("getAppetizers")]
        public List<AppetizerListDTO> GetDrinks()
        {
            return _appetizerService.GetAppetizers();
        }
        [HttpGet("getAppetizer/{id}")]
        public AppetizerEditVM GetDrink(int id)
        {
            return _appetizerService.GetAppetizer(id);
        }
        [HttpPost("edit")]
        public void Edit(AppetizerEditVM model)
        {
            _appetizerService.Edit(model);
        }

        [HttpDelete("deleteAppetizer/{id}")]
        public void DeleteAppetizer(int id)
        {
            _appetizerService.Delete(id);
        }
    }
}
