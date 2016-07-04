using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvsPL.Models
{
    public class TestViewModel
    {
        [Required]
        public int Id { get; set; }
        public int TestId { get; set; }
        [Required(ErrorMessage = "Please, enter the title of new test."), ConcurrencyCheck, MaxLength(20, ErrorMessage = "You title longer than 20 symbols.")]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Please, enter the time to complete of the test.")]
        [RegularExpression(@"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$", ErrorMessage = "Right variant : 00:10:00")]
        public TimeSpan TimeToComplete { get; set; }
        public DateTime DateOfPublication { get; set; }
        [Required(ErrorMessage = "Please, check the category of you test or  add new."), ConcurrencyCheck]
        public string Category { get; set; }
        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}