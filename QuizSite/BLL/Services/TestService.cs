﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TestService:ITestService
    {
        IUnitOfWork Database { get; set; }

        public TestService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public TestDTO GetTest(int? id)
        {
            return Database.Tests.Get(id).ToTestDto();
        }

        public QuestionDTO GetQuestion(int id)
        {
            return Database.Questions.Get(id).ToQuestionDto();
        }

        public IEnumerable<QuestionDTO> GetQuestionsByTestId(int? id)
        {
            return Database.Questions.GetAll().Where(q => q.TestId == id).Select(a => a.ToQuestionDto());
        }
        public IEnumerable<AnswersDTO> GetAnswersByQuestionId(int? id)
        {
            return Database.Answers.GetAll().Where(answerId => answerId.QuestionId == id).Select(answer => answer.ToAnswersDto());
        }
        public IEnumerable<TestDTO> GetTests()
        {
            return Database.Tests.GetAll().Select(test => test.ToTestDto());
        }

        public void Dispose()
        {
            Database.Dispose();
        }


        public void CreateNewTest(TestDTO newTset)
        {
            Database.Tests.Create(newTset.ToTest());
            Database.Save();
        }


        
    }
}
