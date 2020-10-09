using VirtualWaiterCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public interface IDrinkRepository : IRepository<Drink>
    {
        List<DrinkListDTO> GetAll();
    }
}
