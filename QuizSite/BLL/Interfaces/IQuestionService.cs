using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IQuestionService
    {
        QuestionDTO GetQuestion(int? id);
        //QuestionDTO GetQuestionByEmail(string email);
        void CreateNewQuestion(QuestionDTO question);
        IEnumerable<QuestionDTO> GetQuestions();
        IEnumerable<QuestionDTO> GetQuestionsByTestId(int? id);
        void Dispose();
        IEnumerable<AnswersDTO> GetAnswers();
        IEnumerable<AnswersDTO> GetAnswersByQuestionId(int? id);
        void CreateNewAnswer(AnswersDTO answer);
        AnswersDTO GetAnswerById(int id);
    }
}
