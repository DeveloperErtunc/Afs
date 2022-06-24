using AFS.Data.Context;
using AFS.Data.DbModels;
using AFS.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AFS.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(SignInManager<AppUser> signInManager, UserManager<AppUser> appUser) : base(signInManager, appUser)
        {
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    Id = Guid.NewGuid(),
                };

                IdentityResult identityResult = await _appUser.CreateAsync(user, model.Password);
                if (identityResult.Succeeded)
                {
                    if (identityResult.Succeeded)
                        return RedirectToAction(nameof(SignIn));
                }
                identityResult.Errors.ToList().ForEach(x => ModelState.AddModelError("", x.Description));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("GetTranslate", "Translate");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction(nameof(Index), "Translate");
                }
                ModelState.AddModelError("", "Password or Username Incorrect");
            }
            return View(model);
        }
        [Authorize()]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Register));
        }
    }
}
