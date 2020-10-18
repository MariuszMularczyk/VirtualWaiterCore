using VirtualWaiterCore.Domain;
using VirtualWaiterCore.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public class DessertRepository : Repository<Dessert, MainDatabaseContext>, IDessertRepository
    {
        public DessertRepository(MainDatabaseContext context) : base(context)
        { }

        public List<DessertListDTO> GetAll()
        {
            return Context.Desserts.Select(x => new DessertListDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                TimeOfPreparation = x.TimeOfPreparation,
                Image = Convert.ToBase64String(x.Image)
            }).ToList();
        }

    }
}
