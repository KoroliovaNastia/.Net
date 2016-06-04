using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using MvsPL.Models;
using MvsPL.Infrastructure;

namespace MvsPL.Controllers
{
    public class TestController : Controller
    {
        private ITestService testService;

        public TestController(ITestService service)
        {
            testService = service;
        }

        public ActionResult Index()
        {
            return View(testService.GetTests().Select(user => user.ToMvcTest()));
        }
        //protected override void Dispose(bool disposing)
        //{
        //    testService.Dispose();
        //    base.Dispose(disposing);
        //}
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestViewModel testViewModel)
        {
            testService.CreateNewTest(testViewModel.ToBllTest());
            
            return RedirectToAction("Index");
        } 
    }
}
