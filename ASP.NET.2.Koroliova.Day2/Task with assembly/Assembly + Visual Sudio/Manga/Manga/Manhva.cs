using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga
{
    class Manhva
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string AgeCategory { get; set; }

        public Manhva(string title, string author, string ageCategory)
        {
            Title = title;
            Author = author;
            AgeCategory = ageCategory;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}",Title, Author, AgeCategory);
        }
    }
}
