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
    public class DessertController : ControllerBase
    {

        private readonly IDessertService _dessertService;

        public DessertController(IDessertService DessertService)
        {
            _dessertService = DessertService;
        }

        [HttpPost("add")]
        public void Add(DessertAddVM model)
        {
            if (ModelState.IsValid)
            {
                _dessertService.Add(model);
            }
        }

        [HttpGet("getDesserts")]
        public List<DessertListDTO> GetDesserts()
        {
            return _dessertService.GetDesserts();
        }
        [HttpGet("getDessert/{id}")]
        public DessertEditVM GetDessert(int id)
        {
            return _dessertService.GetDessert(id);
        }
        [HttpPost("edit")]
        public void Edit(DessertEditVM model)
        {
            _dessertService.Edit(model);
        }
        [HttpDelete("deleteDessert/{id}")]
        public void DessertDrink(int id)
        {
            _dessertService.Delete(id);
        }
    }
}
