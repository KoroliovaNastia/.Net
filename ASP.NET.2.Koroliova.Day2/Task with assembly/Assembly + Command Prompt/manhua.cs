using System;
namespace Manga
{
    public class Manhua
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string AgeCategory { get; set; }

        public Manhua(string title, string author, string ageCategory)
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