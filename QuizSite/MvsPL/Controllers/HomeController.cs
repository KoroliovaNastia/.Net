﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using MvsPL.Models;

namespace MvsPL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService repository)
        {
            userService = repository;
        }

        public ActionResult Home()
        {
            var model = userService.GetUsers().Select(u => new UserViewModel()
            {
                Email = u.Email,
                CreationDate = u.CreationDate,
                Role = u.Role.Name
            });

            return View(model);
        }

        public ActionResult About()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                ViewBag.AuthType = User.Identity.AuthenticationType;
            }
            ViewBag.Login = User.Identity.Name;
            ViewBag.IsAdminInRole = User.IsInRole("Administrator") ?
                "You have administrator rights." : "You do not have administrator rights.";

            return View();
            //HttpContext.Profile["FirstName"] = "Вася";
            //HttpContext.Profile["LastName"] = "Иванов";
            //HttpContext.Profile.SetPropertyValue("Age",23);
            //Response.Write(HttpContext.Profile.GetPropertyValue("FirstName"));
            //Response.Write(HttpContext.Profile.GetPropertyValue("LastName"));
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult UsersEdit()
        {
            var model = userService.GetUsers().Select(u => new UserViewModel
            {
                Email = u.Email,
                CreationDate = u.CreationDate,
                Role = u.Role.Name
            });

            return View(model);
        }


    }
}
