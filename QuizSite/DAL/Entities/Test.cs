using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Test
    {

        [Required]
        public int Id { get; set; }
        public int TestId { get; set; }
        [Required(ErrorMessage = "Please, enter the title of new test."), ConcurrencyCheck, MaxLength(20, ErrorMessage = "You title longer than 20 symbols.")]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Please, enter the time to complete of the test.")]
        public TimeSpan TimeToComplete { get; set; }
        public DateTime DateOfPublication { get; set; }
        [Required(ErrorMessage = "Please, check the category of you test or  add new."), ConcurrencyCheck]
        public string Category { get; set; }

        public virtual ICollection<Question> Question { get; set; }
    }
}
