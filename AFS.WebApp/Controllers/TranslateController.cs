using AFS.Data.Context;
using AFS.Data.DbModels;
using AFS.Data.Models;
using AFS.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;

namespace AFS.WebApp.Controllers
{
    public class TranslateController : BaseController
    {
        readonly ITranslateService _translateService;
        readonly ILogBusinessService _logBusinessService;
        public TranslateController(ITranslateService translateService, SignInManager<AppUser> signInManager, UserManager<AppUser> appUser, ILogBusinessService logBusinessService) : base(signInManager, appUser)
        {
            _translateService = translateService;
            _logBusinessService = logBusinessService;
        }

        [Authorize]
        public IActionResult GetTranslate()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> GetTranslate(TextOfTranslate textOfTranslate)
        {
            var user = await _appUser.GetUserAsync(User);
            return Json(await _translateService.Translate(textOfTranslate, user));
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(_logBusinessService.GetEntityNoTrack());
        }
    }
}
