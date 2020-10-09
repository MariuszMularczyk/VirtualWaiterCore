using VirtualWaiterCore.Domain;
using VirtualWaiterCore.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public class OrderRepository : Repository<Order, MainDatabaseContext>, IOrderRepository
    {
        public OrderRepository(MainDatabaseContext context) : base(context)
        { }

    }
}
