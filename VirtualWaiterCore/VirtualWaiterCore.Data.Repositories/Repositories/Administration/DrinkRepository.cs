using VirtualWaiterCore.Domain;
using VirtualWaiterCore.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public class DrinkRepository : Repository<Drink, MainDatabaseContext>, IDrinkRepository
    {
        public DrinkRepository(MainDatabaseContext context) : base(context)
        { }

        public List<DrinkListDTO> GetAll()
        {
            return Context.Drinks.Select(x => new DrinkListDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            }).ToList();
        }

    }
}
