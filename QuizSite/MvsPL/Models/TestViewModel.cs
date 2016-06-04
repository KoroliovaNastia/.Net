using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvsPL.Models
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public TimeSpan TimeToComplete { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string Category { get; set; }
    }
}