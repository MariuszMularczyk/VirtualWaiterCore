using VirtualWaiterCore.Application.Abstraction;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VirtualWaiterCore.Data;

namespace VirtualWaiterCore.Application
{
    public interface IDrinkService : IService
    {
        void Add(DrinkAddVM model);
        List<DrinkListDTO> GetDrinks();
        DrinkEditVM GetDrink(int id);
        void Edit(DrinkEditVM model);
        void Delete(int id);
    }
}