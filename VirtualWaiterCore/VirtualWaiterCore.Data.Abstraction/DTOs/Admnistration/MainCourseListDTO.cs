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
    public class MainCourseListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal TimeOfPreparation { get; set; }
        public string Image { get; set; }
    }
}

