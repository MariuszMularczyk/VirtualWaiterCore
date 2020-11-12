using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Resources.Shared;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Application
{
    public class ProductOrderAddVM
    {

        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

