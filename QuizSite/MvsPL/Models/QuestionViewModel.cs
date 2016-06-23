using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvsPL.Models
{
    public class QuestionViewModel
    {
        [Required]
        public int Id { get; set; }

        public int TestViewModelId { get; set; }
        public string Formulation { get; set; }

        public virtual AnswerViewModel TrueAnswer { get; set; }
        public virtual ICollection<AnswerViewModel> Answers { get; set; }

        public string SelectedAnswer { get; set; }
        public virtual TestViewModel Test { get; set; }

    }
}