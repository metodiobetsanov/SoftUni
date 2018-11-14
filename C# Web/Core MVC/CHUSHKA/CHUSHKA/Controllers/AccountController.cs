using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CHUSHKA.Models;
using Microsoft.AspNetCore.Identity;

namespace CHUSHKA.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<ChushkaUser> signInManager;

        public AccountController(SignInManager<ChushkaUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            return null;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var user = new ChushkaUser()
            {
                UserName = model.Username,
                FullName = model.FullName,
                Email = model.Email
            };

            var result = this.signInManager.UserManager.CreateAsync(user, model.Password).Result;

            if (result.Succeeded)
            {
                this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }
    }
}
