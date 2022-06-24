using AFS.Data.Context;
using AFS.Data.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AFS.WebApp.Controllers
{
    public class BaseController : Controller
    {
        public readonly UserManager<AppUser> _appUser;
        public readonly SignInManager<AppUser> _signInManager;
        public BaseController(SignInManager<AppUser> signInManager, UserManager<AppUser> appUser)
        {
            _signInManager = signInManager;
            _appUser = appUser;
        }
    }
}
