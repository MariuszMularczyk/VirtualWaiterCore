﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWaiterCore.Dictionaries;

namespace VirtualWaiterCore.Domain
{
    [Table("Orders")]
    public class Order : Entity
    {
        public string Table { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public OrderStatusEnum AppetizerStatus { get; set; }
        public OrderStatusEnum MainCourseStatus { get; set; }
        public OrderStatusEnum DessertsStatus { get; set; }
        public OrderStatusEnum DrinksStatus { get; set; }
        public virtual List<ProductOrder> ProductOrders { get; set; }
        public DateTime TimeOfOrder { get; set; }

    }
}
