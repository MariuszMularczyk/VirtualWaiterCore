using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWaiterCore.Dictionaries;

namespace VirtualWaiterCore.Domain
{
    [Table("Products")]
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal TimeOfPreparation { get; set; }
        public byte[] Image { get; set; }
        public byte[] ImageTumb { get; set; }
        public ProductType ProductType { get; set; }
        public virtual List<ProductOrder> ProductOrders { get; set; }

    }
}
