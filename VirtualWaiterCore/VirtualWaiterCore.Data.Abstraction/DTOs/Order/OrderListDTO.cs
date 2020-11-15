using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Utils;
using VirtualWaiterCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public class OrderListDTO
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public string Table { get; set; }
        public DateTime TimeOfOrder { get; set; }
        public DateTime? TimeOfSugestedPrepare { get; set; }
        public decimal TimeOfPreparation { get; set; }
        public string Order { get; set; }
        public ProductType ProductType { get; set; }
    }
}

