using VirtualWaiterCore.Application.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Application
{
    public interface IAppUserService : IService
    {
        AppUserData GetFirstUser();
        object GetUsersToList();
        void Add(AppUserAddVM model);
        void Edit(AppUserEditVM model);
        int GetUnknownUserId();
        AppUserData GetUserDataByAdLogin(string userNamePart);
        AppUserListVM GetAppUserListVM();
        void Delete(int id);
    }
}
