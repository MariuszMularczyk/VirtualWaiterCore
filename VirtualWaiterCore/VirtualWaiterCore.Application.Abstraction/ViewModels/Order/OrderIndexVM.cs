using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Resources.Shared;
using VirtualWaiterCore.Utils;
using VirtualWaiterCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Application
{
    public class OrderIndexVM
    {
        public OrderIndexVM()
        {
        }

        public string OrderStatuses { get; set; }
    }
}

