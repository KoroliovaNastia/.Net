using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public  class Answers
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        //public string MyAnswer { get; set; }
        public virtual Question Question { get; set; }
    }
}
