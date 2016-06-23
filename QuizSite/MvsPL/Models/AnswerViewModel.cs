using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvsPL.Models
{
    public class AnswerViewModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        //public string MyAnswer { get; set; }
        public virtual QuestionViewModel Question { get; set; }
    }
}