using EDuBee.Classes;
using EDuBee.Client.Service;
using EDuBee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee.Client.Controllers
{
    public class UserController : Controller
    {
        private readonly IAccountApiClient _accountApiClient;

        public UserController(IAccountApiClient accountApiClient)
        {
            _accountApiClient = accountApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string UserName, string Password)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            LoginRequest request = new LoginRequest
            {
                UserName = UserName,
                PassWord = Password
            };
            var token = await _accountApiClient.Login(request);
            //if (int.Parse(token) == 0 || int.Parse(token) == 1)
            //{
            //    var user = await _accountApiClient.GetAccountByUserName(UserName);
            //    var userSession = new UserAccount();
            //    userSession.UserName = user.UserName;
            //    userSession.IduserAccount = user.IduserAccount;
            //    HttpContext.Session.Set(Common.CommonConstants.USER_SESSION, userSession.UserName.ToString);
            //}
            if (int.Parse(token) == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            //else
            //{
            //    if (int.Parse(token) == 1)
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "đăng nhập không đúng.");
            //    }
            //}
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var listProvince = _accountApiClient.GetProvinces();
            ViewBag.provinceID = new SelectList(listProvince, "idprovince", "name");
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterAccount registerAccount)
        {
            var result = _accountApiClient.Register(registerAccount);
            if (result)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
    }
}
