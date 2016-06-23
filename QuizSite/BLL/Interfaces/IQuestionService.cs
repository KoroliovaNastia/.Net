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
        QuestionDTO GetQuestionByEmail(string email);
        void CreateNewQuestion(QuestionDTO question);
        IEnumerable<QuestionDTO> GetQuestions();
        void Dispose();
    }
}
