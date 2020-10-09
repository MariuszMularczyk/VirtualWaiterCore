using VirtualWaiterCore.Data;
using VirtualWaiterCore.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWaiterCore.Resources.Shared;

namespace VirtualWaiterCore.Application
{
    public class ApplicationFileService : ServiceBase, IApplicationFileService
    {
        #region Dependencies
        public IApplicationFileRepository ApplicationFileRepository { get; set; }
        #endregion

        public ImageVM GetImage(int id)
        {
            ApplicationFile file = new ApplicationFile();
            file = ApplicationFileRepository.GetImage(id);
            if (file == null)
                throw new BussinesException(502, ErrorResource.NoData);
            ImageVM result = new ImageVM
            {
                Content = file.Content,
                Type = file.ContentType
            };
            return result;
        }
    }
}
