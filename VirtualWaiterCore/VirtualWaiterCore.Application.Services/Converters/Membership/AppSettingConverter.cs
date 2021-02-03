using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Application
{
    public class AppSettingConverter : ConverterBase
    {
        
        public AppSetting FromAppSettingAddVM(AppSettingAddVM model)
        {
            AppSetting setting = new AppSetting
            {
                Value = model.Value,
                Type = model.Type,
            };
            return setting;
        }

      
    }
}
