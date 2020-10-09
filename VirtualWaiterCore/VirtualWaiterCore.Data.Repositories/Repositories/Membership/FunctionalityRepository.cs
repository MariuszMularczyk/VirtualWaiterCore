using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using VirtualWaiterCore.EntityFramework;
using VirtualWaiterCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public class FunctionalityRepository : Repository<Functionality, MainDatabaseContext>, IFunctionalityRepository
    {
        public FunctionalityRepository(MainDatabaseContext context)
         : base(context)
        {
        }


    }
}
