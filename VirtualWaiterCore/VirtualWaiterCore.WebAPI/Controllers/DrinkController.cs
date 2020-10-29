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
    public class DrinkController : ControllerBase
    {

        private readonly IDrinkService _drinkService;

        public DrinkController(IDrinkService DrinkService)
        {
            _drinkService = DrinkService;
        }

        [HttpPost("add")]
        public void Add(DrinkAddVM model)
        {
            if (ModelState.IsValid)
            {
                _drinkService.Add(model);
            }
        }

        [HttpGet("getDrinks")]
        public List<DrinkListDTO> GetDrinks()
        {
            return _drinkService.GetDrinks();
        }
        [HttpGet("getDrink/{id}")]
        public DrinkEditVM GetDrink(int id)
        {
            return _drinkService.GetDrink(id);
        }
        [HttpPost("edit")]
        public void Edit(DrinkEditVM model)
        {
            _drinkService.Edit(model);
        }
        [HttpDelete("deleteDrink/{id}")]
        public void DeleteDrink(int id)
        {
             _drinkService.Delete(id);
        }
    }
}
