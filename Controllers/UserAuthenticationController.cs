using Microsoft.AspNetCore.Mvc;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheChampions.Models.DTO;
using TheChampions.Repository.Abstract;

namespace TheChampions.Controllers

{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService = authService;
        }
        [AllowAnonymous]
        //public async Task<IActionResult> RegisterAdmin()
        //{

        //    var model = new RegistrationModel
        //    {
        //        Email = "admin@gmail.com",
        //        UserName = "admin",
        //        Name = "admin",
        //        //First_Name = "admin",
        //        //Last_Name = "admin",
        //        Password = "Admin@123",
        //        //PasswordConfirm = "Admin@123",
                
        //    };

        //    model.Role = "admin";
        //    var result = await authService.RegistrationAsync(model);
        //    return Ok(result);
        //}
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {

            if (!ModelState.IsValid)
                return View(model);
            model.Role = "user";
            var result = await authService.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1)
                return RedirectToAction("Index", "Home");
            else
            {
                TempData["msg"] = result.Message/*"Could not logged in.."*/;
                return RedirectToAction(nameof(Login));
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}

