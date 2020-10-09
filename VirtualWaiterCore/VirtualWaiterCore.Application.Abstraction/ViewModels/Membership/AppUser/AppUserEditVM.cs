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
    public class AppUserEditVM
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool IsActive { get; set; }
        public AppRoleType Role { get; set; }
    }
}
