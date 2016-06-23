using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvsPL.Models
{
    public class UserAnswers
    {
        public ICollection<AnswerViewModel> MyAnswers { get; set; }
        public int Count { get; set; }
    }
}