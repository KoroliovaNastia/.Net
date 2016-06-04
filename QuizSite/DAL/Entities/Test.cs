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
        [Required, ConcurrencyCheck,MaxLength(20)]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        [Required]
        public TimeSpan TimeToComplete { get; set; }
        public DateTime DateOfPublication { get; set; }
        [Required, ConcurrencyCheck]
        public string Category { get; set; }
       
    }
}
