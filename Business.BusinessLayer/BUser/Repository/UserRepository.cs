using Business.BusinessLayer.BUser.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Data.EntityModels;
using Data.ViewModels.DataUserVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Business.BusinessLayer.BUser.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly RoleManager<IdentityRole> RoleManager;
        public readonly SignInManager<IdentityUser> SignInManager;
        
        public readonly UserManager<IdentityUser> UserManager;
        public readonly IMapper Mapper;
        public readonly IHttpContextAccessor ContextAccessor;

        public UserRepository(
            IMapper mapper,
            UserManager<IdentityUser> user,
            RoleManager<IdentityRole> role,
            SignInManager<IdentityUser> signIn,
          
            IHttpContextAccessor context)
        {
            ContextAccessor = context;
            this.Mapper = mapper;
            RoleManager = role;
            UserManager = user;
            SignInManager = signIn;
           
        }

        public bool Login(LoginVm login)
        {
            if (login == null)
            {
                return false;
            }
            var res = SignInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false).Result;
            return res.Succeeded;
        }
        public bool Register(RegisterVm newUser)
        {
            if (newUser == null)
            {
                return false;
            }
            User user = Mapper.Map<User>(newUser);

            var res = UserManager.CreateAsync(user, newUser.Password).Result;
            if (res.Succeeded)
            {
                LoginVm login = Mapper.Map<LoginVm>(newUser);
                var resp = Login(login);
                return resp;
            }
            return false;
        }
        public bool ChangePwd(CheckPwVm pw)
        {
            var getUser = (User)GetCurrentUser();
            var check = UserManager.CheckPasswordAsync(getUser, pw.CurrentPassword).Result;
            if (check)
            {

                var change = UserManager.ChangePasswordAsync(getUser, pw.CurrentPassword, pw.NewPassword).Result;
                return true;
            }
            return false;
        }
        public bool DisableAccount(ManageProfileVm profile)
        {
            var getUser = GetCurrentUser();
            var check = UserManager.CheckPasswordAsync(getUser, profile.Password).Result;

            if (check)
            {

                if (getUser != null)
                {
                    SignInManager.SignOutAsync();
                    UserManager.DeleteAsync(getUser);

                }
                return true;
            }
            return false;
        }
        [Authorize]
        public IdentityUser GetCurrentUser()
        {
            var userId = UserManager.GetUserAsync(ContextAccessor.HttpContext.User).Result;
            return userId;
        }
        public bool UpadateAccount(ManageProfileVm profile)
        {
            User resp = (User)UserManager.GetUserAsync(ContextAccessor.HttpContext.User).Result;
            resp.FirstName = profile.FirstName;
            resp.LastName = profile.LastName;
            resp.Country = profile.Country;
            resp.City = profile.City;
            resp.PhoneNumber = profile.PhoneNumber;
            resp.Bio = profile.Bio;
            _ = UserManager.UpdateAsync(resp).Result;
            return true;
        }
        public bool LogOut()
        {
            var res = SignInManager.SignOutAsync();
            return true;
        }
        public ManageProfileVm GetUsrInfo()
        {
            User resp = (User)GetCurrentUser();
            var data = Mapper.Map<ManageProfileVm>(resp);
            return data;
        }
        public MyProfileVm MyProfile()
        {
            var user = GetCurrentUser();
            var data = Mapper.Map<MyProfileVm>(user);
            return data;
        }

        public bool UploadUserImage(Image file)
        {

            if (file != null)
            {
                var guid = Guid.NewGuid().ToString();
                var path = Path.Combine("Images", guid + file.FormFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }
                var currUser = (User)UserManager.GetUserAsync(ContextAccessor.HttpContext.User).Result;
                if (currUser != null)
                {
                    if (file.ImageP)
                    {
                        currUser.ImageName = guid + file.FormFile.FileName;
                        currUser.ImagePath = path;
                    }
                    else
                    {
                        currUser.CoverPath = path;
                        currUser.CoverName = guid + file.FormFile.FileName;
                    }
                }
                _ = UserManager.UpdateAsync(currUser).Result;
                return true;
            }


            return false;

        }
    }
}

