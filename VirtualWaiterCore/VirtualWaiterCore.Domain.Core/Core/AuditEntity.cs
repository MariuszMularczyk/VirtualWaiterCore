﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Domain
{
    public abstract class AuditEntity : Entity, IAuditEntity
    {
        public int? CreatedById { get; set; }
        public virtual Person CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedById { get; set; }
        public virtual Person ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public abstract class AuditEntity<T> : Entity<T>, IAuditEntity where T : Type
    {
        public int? CreatedById { get; set; }
        public virtual Person CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedById { get; set; }
        public virtual Person ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
