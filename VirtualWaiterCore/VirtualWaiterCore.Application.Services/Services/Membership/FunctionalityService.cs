using VirtualWaiterCore.Data;
using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using VirtualWaiterCore.Infrastructure;
using VirtualWaiterCore.Resources.Shared;
using VirtualWaiterCore.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Application
{
    public class FunctionalityService : ServiceBase, IFunctionalityService
    {
        #region Dependencies
        public IFunctionalityRepository FunctionalityRepository { get; set; }
        #endregion

    }
}
