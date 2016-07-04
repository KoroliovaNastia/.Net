using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
   public interface ITestService
    {
        TestDTO GetTest(int? id);
        void CreateNewTest(TestDTO test);
        IEnumerable<TestDTO> GetTests();
        void Dispose();
       QuestionDTO GetQuestion(int id);
       IEnumerable<QuestionDTO> GetQuestionsByTestId(int? id);
       IEnumerable<AnswersDTO> GetAnswersByQuestionId(int? id);
    }
}
