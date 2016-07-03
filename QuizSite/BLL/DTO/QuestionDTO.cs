using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class QuestionDTO
    {
        [Required]
        public int Id { get; set; }

        public int TestDtoId { get; set; }
        public string Formulation { get; set; }

        public string TrueAnswer { get; set; }

        public string SelectedAnswer { get; set; }
    }
}
