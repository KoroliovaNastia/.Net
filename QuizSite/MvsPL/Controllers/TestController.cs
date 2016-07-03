using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using Microsoft.Ajax.Utilities;
using MvsPL.Models;
using MvsPL.Infrastructure;
using PagedList;
using PagedList.Mvc;

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
            return View();
        }
        [HttpGet]
        //public ActionResult GetTest()
        //{
        //    return View();
        //}

        //[HttpPost]
        public ActionResult GetTest(int? id)
        {
            return View(testService.GetTest(id).ToMvcTest());
        }

        public ActionResult AllTests(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(testService.GetTests().Select(user => user.ToMvcTest()).ToPagedList(pageNumber,pageSize));
        }

        //protected override void Dispose(bool disposing)
        //{
        //    testService.Dispose();
        //    base.Dispose(disposing);
        //}
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestViewModel testViewModel)
        {
            testViewModel.DateOfPublication = DateTime.Now;
            testService.CreateNewTest(testViewModel.ToBllTest());
            return RedirectToAction("AllTests");
        }

        [HttpGet]
        [Authorize]
        public ActionResult PassTest()
        {


            //the below is hardcoded for DEMO. you may get the data from some  
            //other place and set the questions and answers

            QuestionViewModel q1 = new QuestionViewModel
            {
                Id = 1,
                Formulation = "What is your favourite language",
                TrueAnswer  = "ASP.NET",
                Answers = new List<AnswerViewModel>
                {
                    new AnswerViewModel {Id = 1, Text = "PHP"},
                    new AnswerViewModel {Id = 2, Text = "ASP.NET"},
                    new AnswerViewModel {Id = 3, Text = "Java"}
                }
            };


            QuestionViewModel q2 = new QuestionViewModel
            {
                Id = 2,
                Formulation = "What is your favourite DB",
                TrueAnswer ="SQL Server",
                Answers = new List<AnswerViewModel>
                {
                    new AnswerViewModel {Id = 4, Text = "SQL Server"},
                    new AnswerViewModel {Id = 5, Text = "MyQL"},
                    new AnswerViewModel {Id = 6, Text = "Oracle"}
                }
            };

            TestViewModel test = new TestViewModel
            {
                Title = "Your favourite tools",
                Category = "Programming",
                DateOfPublication = DateTime.Now,
                ShortDescription = "Simple question",
                TimeToComplete = new TimeSpan(0, 10, 0),
                Questions = new List<QuestionViewModel> {q1, q2}
            };
            return View(test);
        }

        //public ActionResult PassTest()
        //{

        //    return View((TestViewModel) testService.GetTest(id));
        //}

        [HttpPost]
        public ActionResult PassTest(TestViewModel model)
        {
            List<int> ids = new List<int>();
            //if (ModelState.IsValid)
            //{
            foreach (var q in model.Questions)
            {
                ids.Add(q.Id);
                //var qId = q.Id;
                //var selectedAnswer = q.SelectedAnswer;
                //us.MyAnswers.Add(new AnswerViewModel { Id = qId, Text = selectedAnswer });
                // Save the data 
            }
            //    //return RedirectToAction("Result"); //PRG Pattern
            //}
            //to do : reload questions and answers
            //return View(model);
            return RedirectToAction("SaveMyAnswers", "Home", new{ answersId= (IEnumerable<int>)ids});
        }
        //[HttpGet]
        //public ActionResult Result(UserAnswers us)
        //{
        //    return View(us.MyAnswers);
        //}
        //[HttpPost]
        //public ActionResult Result(UserAnswers user)
        //{
        //    return View(user);
        //}
        [HttpPost]
        public ActionResult GetQuestion(int? idTest)
        {

            return Json(testService.GetTest(idTest));
        }

       
    }
}
