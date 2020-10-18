using VirtualWaiterCore.Domain;
using VirtualWaiterCore.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public class AppetizerRepository : Repository<Appetizer, MainDatabaseContext>, IAppetizerRepository
    {
        public AppetizerRepository(MainDatabaseContext context) : base(context)
        { }

        public List<AppetizerListDTO> GetAll()
        {
            return Context.Appetizers.Select(x => new AppetizerListDTO()
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
