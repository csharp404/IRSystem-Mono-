using Business.BusinessLayer.BUser.IRepository;
using Data.ViewModels.DataUserVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace RESProject101.Controllers
{

    public class AccountController : Controller
    {

        public IUserRepository UserRepository;
        public AccountController(
                                 IUserRepository userRepository

                                )
        {
            UserRepository = userRepository;
        }
        [HttpPost]


        public async Task<IActionResult> Login(LoginVm data)
        {
          var res =  UserRepository.Login(data);
            if (res)
            {
                return RedirectToAction("Index", "Home");
            }
                return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm data)
        {
           
           var res =  UserRepository.Register(data);
            if (res)
            {
                return RedirectToAction("Index", "Home");  
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Logout()
        {
            var res = UserRepository.LogOut();
            if (res)
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Manage(string message)
        {

         var data =   UserRepository.GetUsrInfo();
            if (TempData["mess"] != null)
            {
                data.ValidationMessage = TempData["mess"]?.ToString();
                TempData["mess"] = null;
            }
            if (data != null)
            {
                return View(data);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Manage(ManageProfileVm data)
        {

          var f =  UserRepository.UpadateAccount(data);

            if (f)
            {
                return RedirectToAction("Manage", "Account");
            }
            return View(data);

        }




        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteAccount(ManageProfileVm pw)
        {
  
                if (UserRepository.DisableAccount(pw))
                {
                   
                return RedirectToAction("Register", "Account");

                }
                else
                {
                    TempData["mess"] = "Couldn't disable your account ,Your password is wrong...!!";
                }
            return RedirectToAction("Manage", "Account");

        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(CheckPwVm pw)
        {
            
           

               

                if (UserRepository.ChangePwd(pw))
                {

            
                        return RedirectToAction("Logout");

                }
                else
                {

                    TempData["mess"] = " couldn't change password ,Current password or new password is incorrect...!";


                    return RedirectToAction("Manage", "Account");
                }
            
       

        }



        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyProfile()
        {
           var  data = UserRepository.MyProfile();

            return View(data);
        }
        [Authorize]
        public async Task<IActionResult> UploadProfile(Image file)
        {
            UserRepository.UploadUserImage(file);
            return RedirectToAction("MyProfile");
        }

        
    }
}
