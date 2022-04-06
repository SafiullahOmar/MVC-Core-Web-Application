﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserAuthController(ApplicationDbContext context,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) {

            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModal loginModal) {
            loginModal.LoginInvalid = "true";
            if (ModelState.IsValid) {
                var result =await _signInManager.PasswordSignInAsync(loginModal.Email, loginModal.Password, loginModal.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    loginModal.LoginInvalid = "";
                }
                else {
                    ModelState.AddModelError(string.Empty, "Invalid Attempt");
                }
            }
            return PartialView("_loginModalPartial", loginModal);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnURL = "") {
            await _signInManager.SignOutAsync();
            if (returnURL != null)
            {
                return LocalRedirect(returnURL);
            }
            else {
               return RedirectToAction("Index", "Home");
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterUser( RegistrationModal registrationModal) {
            registrationModal.RegistrationInValid = "true";
            if (ModelState.IsValid) {
                ApplicationUser user = new ApplicationUser { 
                Email=registrationModal.Email,
                UserName=registrationModal.Email,
                FirstName=registrationModal.FirstName,
                LastName=registrationModal.LastName,
                Address=registrationModal.Address,
                PostCode=registrationModal.PostCode
                };

                var result = await _userManager.CreateAsync(user, registrationModal.Password);
                if (result.Succeeded) {
                    registrationModal.RegistrationInValid = "";
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return PartialView("_RegistrationModalPartial", registrationModal);
                }
                ModelState.AddModelError("", "Registration Failure");

            }
            return PartialView("_RegistrationModalPartial", registrationModal);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
