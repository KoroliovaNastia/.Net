using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TestDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public TimeSpan TimeToComplete { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string Category { get; set; }
    }
}
