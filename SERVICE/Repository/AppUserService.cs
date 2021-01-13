using MODEL.Entities;
using SERVICE.Base;
using SERVICE.ViewModels.AppUserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Repository
{
    public class AppUserService : BaseService<AppUser>
    {
        public bool Login(AppUser loginVm)
        {
            return Any(x => x.UserName == loginVm.UserName && x.Password == loginVm.Password);
        }

        public AppUser GetUser(AppUser loginVM)
        {
            AppUser user = null;
            user = GetSingle(x => x.UserName == loginVM.UserName);
            return user;
        }
        


    }
}
