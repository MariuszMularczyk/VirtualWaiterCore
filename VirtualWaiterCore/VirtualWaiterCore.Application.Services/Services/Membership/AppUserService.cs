using VirtualWaiterCore.Data;
using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using VirtualWaiterCore.EntityFramework;
using VirtualWaiterCore.Infrastructure;
using VirtualWaiterCore.Resources.Shared;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Application
{
    public class AppUserService : ServiceBase, IAppUserService
    {
        #region Dependencies
        public IAppUserRepository AppUserRepository { get; set; }
        public ILanguageRepository LanguageRepository { get; set; }
        public AppUserRoleService AppUserRoleService { get; set; }
        public AppUserConverter AppUserConverter { get; set; }
        public IAppRoleRepository AppRoleRepository { get; set; }
        public IAppUserRoleRepository AppUserRoleRepository { get; set; }
        public IAppRoleService AppRoleService { get; set; }
        public AppUserRoleConverter AppUserRoleConverter { get; set; }
        #endregion

        public string GetActiveUserIdByEmail(string email)
        {
            return AppUserRepository.GetActiveUserIdByEmail(email);
        }

        public AppUserData GetFirstUser()
        {
            AppUser user = AppUserRepository.GetSingle(x => x.Email == "admin@pl.pl");
            if (user == null)
            {
                user = AppUserRepository.GetAll(x => x.LastName != null && x.LastName != "").OrderBy(x => x.LastName).FirstOrDefault();
            }
            AppUserData result = new AppUserData()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Email,
                Functionalities = EnumHelpers.GetEnumList<FunctionalityType>(),
                Language = user.Language.LanguageDictionary,
                Login = user.Login,
                IsActive = user.IsActive,
                //Roles = EnumHelpers.GetEnumList<AppRoleType>(),
                Roles = user.AppUserRoles.Select(x => x.AppRole.AppRoleType).ToList()
            };
            return result;
        }

        public AppUserListVM GetAppUserListVM()
        {
            AppUserListVM model = new AppUserListVM()
            {
                AppRoleTypesJSON = EnumHelpers.GetEnumBinderListJson<AppRoleType>()
            };
            return model;
        }

        public AppUserDetailsVM GetAppUserDetailsVM(int userId)
        {
            AppUser crmUser = AppUserRepository.GetSingle(x => x.Id == userId);
            AppUserDetailsVM result = AppUserConverter.ToAppUserDetailsVM(crmUser);
            return result;
        }

        public void Add(AppUserAddVM model)
        {
            if (AppUserRepository.Any(x => x.Login == model.Login))
                throw new BussinesException(1000, ErrorResource.UserAlreadyAdded);
            Language language = LanguageRepository.GetSingle(x => x.CultureSymbol == "pl-PL");
            AppUser user = new AppUser()
            {
                CreatedById = MainContext.PersonId,
                CreatedDate = DateTime.Now,
                IsActive = model.IsActive,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Login = model.Login,
                LanguageId = language.Id,
            };
            AppUserRepository.Add(user);
            AppUserRepository.Save();

            if (model.Role == AppRoleType.Administrator)
            {
                AppRole admin = AppRoleRepository.GetSingle(x => x.AppRoleType == AppRoleType.Administrator);
                if (admin == null)
                {
                    admin = AppRoleService.AddRole(AppRoleType.Administrator, "Administratorzy", "Grupa administrator�w systemu");
                }
                AppUserRole appUserRole = new AppUserRole()
                {
                    AppRoleId = admin.Id,
                    AppUserId = user.Id,
                };
                AppUserRoleRepository.Add(appUserRole);
            }
            AppUserRoleRepository.Save();
        }

        public void Edit(AppUserEditVM model)
        {
            AppUser appUser = AppUserRepository.GetSingle(x => x.Id == model.Id);
            if (appUser == null)
            {
                throw new BussinesException(1001, ErrorResource.NoData);
            }
            appUser = AppUserConverter.FromAppUserEditVM(model, appUser);
            AppUserRepository.Edit(appUser);


            AppRole appRole = AppRoleRepository.GetSingle(x => x.AppRoleType == model.Role);
            if (appRole == null)
            {
                if (model.Role == AppRoleType.Administrator)
                    appRole = AppRoleService.AddRole(AppRoleType.Administrator, "Administratorzy", "Grupa administrator�w systemu");
            }
            AppUserRole appUserRole = AppUserRoleRepository.GetSingle(x => x.AppUserId == model.Id);
            if (appUserRole == null)
            {
                appUserRole = new AppUserRole()
                {
                    AppRoleId = appRole.Id,
                    AppUserId = appUser.Id
                };
                AppUserRoleRepository.Add(appUserRole);
                AppUserRoleRepository.Save();
            }
            appUserRole = AppUserRoleConverter.FromAppUserEditVM(appUserRole, appRole);
            AppUserRoleRepository.Edit(appUserRole);
        }

        public void Delete(int id)
        {
            AppUser appUser = AppUserRepository.GetSingle(x => x.Id == id);
            if (appUser == null)
            {
                throw new BussinesException(1002, ErrorResource.NoData);
            }
            AppUserRole appUserRole = AppUserRoleRepository.GetSingle(x => x.AppUserId == id);
            if (appUserRole == null)
            {
                throw new BussinesException(1003, ErrorResource.NoData);
            }
            AppUserRoleRepository.Delete(appUserRole);
            AppUserRepository.Delete(appUser);
        }

        public object GetUsersToLookup()
        {
            return AppUserRepository.GetUsersLookup();
        }

        public object GetUsersToList()
        {
            return AppUserRepository.GetUsersToList();
        }

        public int GetUnknownUserId()
        {
            return AppUserRepository.GetUnknownUserId();
        }

        public AppUserData GetUserDataByAdLogin(string userNamePart)
        {
            AppUser user = AppUserRepository.GetSingle(x => x.Login == userNamePart);
            if (user == null)
                return null;
            AppUserData result = new AppUserData()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Email,
                Functionalities = EnumHelpers.GetEnumList<FunctionalityType>(),
                Language = user.Language.LanguageDictionary,
                Login = user.Login,
                IsActive = user.IsActive,
                Roles = user.AppUserRoles.Select(x => x.AppRole.AppRoleType).ToList(),
            };
            return result;
        }
    }
}
