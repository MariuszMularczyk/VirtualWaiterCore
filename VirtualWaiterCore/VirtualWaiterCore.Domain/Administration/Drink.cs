﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWaiterCore.Dictionaries;

namespace VirtualWaiterCore.Domain
{
    [Table("Drinks")]
    public class Drink : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
