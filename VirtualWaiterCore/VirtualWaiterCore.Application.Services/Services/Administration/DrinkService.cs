using VirtualWaiterCore.Application.Abstraction;
using VirtualWaiterCore.Data;
using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Application
{
    public class DrinkService : ServiceBase, IDrinkService
    {

        public IDrinkRepository _drinkRepository { get; set; }
        public DrinkService(IDrinkRepository DrinkRepository)
        {
            _drinkRepository = DrinkRepository;
        }

        public void Add(DrinkAddVM model)
        {
            Drink drink = new Drink()
            {
                Description = model.Description,
                Name = model.Name,
                Price = model.Price
            };
            _drinkRepository.Add(drink);
            _drinkRepository.Save();
        }
        public List<DrinkListDTO>GetDrinks()
        {
            return _drinkRepository.GetAll();
        }
    }
}
