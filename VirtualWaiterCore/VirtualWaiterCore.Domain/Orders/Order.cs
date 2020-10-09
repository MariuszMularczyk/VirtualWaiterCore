using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWaiterCore.Dictionaries;

namespace VirtualWaiterCore.Domain
{
    [Table("Orders")]
    public class Order : AuditEntity
    {
        public string Description { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
    }
}
