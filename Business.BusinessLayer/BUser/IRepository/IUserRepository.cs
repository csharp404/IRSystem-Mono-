using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Data.ViewModels.DataUserVM;
using Microsoft.AspNetCore.Identity;

namespace Business.BusinessLayer.BUser.IRepository
{
    public interface IUserRepository
    {
        public bool Login(LoginVm login);
        public bool Register(RegisterVm newUser);
        public bool ChangePwd(CheckPwVm pw);
        public bool DisableAccount(ManageProfileVm profile);
        public bool UpadateAccount(ManageProfileVm profile);
        public IdentityUser GetCurrentUser();
        public bool LogOut();
        public ManageProfileVm GetUsrInfo();
        public MyProfileVm MyProfile();
        public bool UploadUserImage(Image file);
    }
}
