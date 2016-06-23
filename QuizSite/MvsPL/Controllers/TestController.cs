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

        public ActionResult Home()
        {
            return View();
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
            testViewModel.DateOfPublication = DateTime.Now;
            testService.CreateNewTest(testViewModel.ToBllTest());

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PassTest()
        {


            //the below is hardcoded for DEMO. you may get the data from some  
            //other place and set the questions and answers

            QuestionViewModel q1 = new QuestionViewModel
            {
                Id = 1,
                Formulation = "What is your favourite language",
                TrueAnswer = new AnswerViewModel {Text = "ASP.NET"},
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
                TrueAnswer = new AnswerViewModel {Text = "SQL Server"},
                Answers = new List<AnswerViewModel>
                {
                    new AnswerViewModel {Id = 1, Text = "SQL Server"},
                    new AnswerViewModel {Id = 2, Text = "MyQL"},
                    new AnswerViewModel {Id = 3, Text = "Oracle"}
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
            UserAnswers us = new UserAnswers() {MyAnswers = new List<AnswerViewModel>()};
            //if (ModelState.IsValid)
            //{
            foreach (var q in model.Questions)
            {
                var qId = q.Id;
                var selectedAnswer = q.SelectedAnswer;
                us.MyAnswers.Add(new AnswerViewModel { Id = qId, Text = selectedAnswer });
                // Save the data 
            }
            //    //return RedirectToAction("Result"); //PRG Pattern
            //}
            //to do : reload questions and answers
            //return View(model);
            return View("Result",us.MyAnswers);
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
        //public ActionResult GetQuestion(TestViewModel test, int id)
        //{
        //    ICollection<QuestionViewModel> questions = test.Questions;
        //    return View(test.GetQuestion());

        //}
    }
}
