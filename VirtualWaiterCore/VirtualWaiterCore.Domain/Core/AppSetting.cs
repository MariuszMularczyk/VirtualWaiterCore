using VirtualWaiterCore.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Domain
{
    public class AppSetting : Entity
    {
        public string Value { get; set; }
        public AppSettingEnum Type { get; set; }
    }
}
