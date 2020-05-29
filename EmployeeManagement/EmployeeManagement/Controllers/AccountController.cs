using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("Account")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        //Login Next Two
        [Route("Login")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
              var result= await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if(result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else {
                    return RedirectToAction("Index", "Home");
                    }

                }
               else
                {
                    return RedirectToAction("Login", "Account");


                }

            }


            return View(model);
        }



        //Register Next Two



        [Route("SignOut")]
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
           await signInManager.SignOutAsync();

            return View();
        }




        [Route("Register")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }


        [Route("Register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var identityuser = new IdentityUser { UserName = model.Email,Email=model.Email };
                var result= await userManager.CreateAsync(identityuser,model.Password); 

                if(result.Succeeded)
                {
                   await signInManager.SignInAsync(identityuser, false);
                   return RedirectToAction("Index", "Home");

                }
                else
                {
                   return RedirectToAction("Register", "Account");
                }

            }


            return View(model);
        }
    }
}
