using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Services
{
    class QuestionService:IQuestionService
    {
        IUnitOfWork Database { get; set; }

        public QuestionService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public QuestionDTO GetQuestion(int? id)
        {
            return Database.Questions.Get(id).ToQuestionDto();
        }

        public IEnumerable<QuestionDTO> GetQuestions()
        {
            return Database.Questions.GetAll().Select(question => question.ToQuestionDto());
        }

        public void Dispose()
        {
            Database.Dispose();
        }


        public void CreateNewQuestion(QuestionDTO newQuestion)
        {
            Database.Questions.Create(newQuestion.ToQuestion());
            Database.Save();
        }
    }
}
