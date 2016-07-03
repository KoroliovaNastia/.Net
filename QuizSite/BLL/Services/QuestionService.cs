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
    public class QuestionService:IQuestionService
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

        public IEnumerable<AnswersDTO> GetAnswers()
        {
            return Database.Answers.GetAll().Select(answer => answer.ToAnswersDto());
        }

        public IEnumerable<AnswersDTO> GetAnswersByQuestionId(int? id)
        {
            return Database.Answers.GetAll().Select(answer => answer.ToAnswersDto()).Where(answerId=>answerId.QuestionId==id);
        }

        public AnswersDTO GetAnswerById(int id)
        {
            return Database.Answers.Get(id).ToAnswersDto();
        }

        public void CreateNewAnswer(AnswersDTO newAnswer)
        {
            Database.Answers.Create(newAnswer.ToAnswers());
            Database.Save();
        }
        public IEnumerable<QuestionDTO> GetQuestionsByTestId(int? id)
        {
            return Database.Questions.GetAll().Select(question => question.ToQuestionDto()).Where(questionTestId => questionTestId.TestDtoId == id);
        }
    }
}
