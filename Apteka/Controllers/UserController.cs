using Apteka.Models;
using ClientLogic.Interfaces;
using ClientLogic.Models;
using ClientLogic.Services;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Apteka.Controllers
{
    public class UserController : Controller
    {
        private readonly IClientService _userService = new ClientService();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var address = new AddressModel()
                {
                    City = model.City,
                    ApartmentNumber = model.ApartmentNumber,
                    HouseNumber = model.HouseNumber,
                    Street = model.Street,
                    ZipCode = model.ZipCode
                };

                var user = new UserModel()
                {
                    CreationDate = DateTime.Now,
                    NIP = model.NIP,
                    Address = address,
                    Email = model.Email,
                    PasswordHash = Helpers.HashProvider.GetHash(model.Password)
                };

                var success = _userService.Add(user);

                if (!success)
                {
                    ModelState.AddModelError(string.Empty, "Wystapił nieznany problem, spróbuj ponownie później");
                    return View(model);
                }

                FormsAuthentication.SetAuthCookie(user.Email, false);
                Session["User"] = user;

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUserViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                model.Password = Helpers.HashProvider.GetHash(model.Password);

                var user = _userService.Get(model.Login);

                if (user != null && model.Password.Equals(user.PasswordHash))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    Session["User"] = user;
                    return Redirect(returnUrl);
                }
                ModelState.AddModelError(string.Empty, "Nie ma takiego użytkownika, lub hasło się nie zgadza");
            }
            return View();
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}