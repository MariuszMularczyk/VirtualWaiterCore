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
                Price = model.Price,
                TimeOfPreparation = model.TimeOfPreparation,
                Image = Convert.FromBase64String(model.Image)
            };
            _drinkRepository.Add(drink);
            _drinkRepository.Save();
        }
        public List<DrinkListDTO>GetDrinks()
        {
            return _drinkRepository.GetAll();
        }

        public DrinkEditVM GetDrink(int id) {

            Drink drink = _drinkRepository.GetSingle(x => x.Id == id);
            DrinkEditVM model = new DrinkEditVM()
            {
                Id = drink.Id,
                Name = drink.Name,
                Description = drink.Description,
                Price = drink.Price,
                TimeOfPreparation = drink.TimeOfPreparation,
                Image = Convert.ToBase64String(drink.Image)
            };
            return model;
        }
        public void Edit(DrinkEditVM model)
        {
            Drink drink = new Drink()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                TimeOfPreparation = model.TimeOfPreparation,
                Image = Convert.FromBase64String(model.Image)
            };
            _drinkRepository.Edit(drink);
            _drinkRepository.Save();
        }

    }
}
