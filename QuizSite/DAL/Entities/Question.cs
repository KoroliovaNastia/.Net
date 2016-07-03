using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
  public  class Question
    {
        [Required]
        public int Id { get; set; }

        public int TestId { get; set; }
        public string Formulation { get; set; }

        public string TrueAnswer { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }

        public string SelectedAnswer { get; set; }
        public virtual Test Test { get; set; }

    }
}
