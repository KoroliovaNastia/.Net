using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchConsole
{
    public class Book:IComparable<Book>
    {
        #region Ctor

        public Book(string name, string author, int ageOfPublication)
        {
            AgeOfPublication = ageOfPublication;
            Author = author;
            Name = name;
        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public string Author { get; private set; }
        public int AgeOfPublication { get; private set; }

        #endregion

        #region Public Methods

        public int CompareTo(Book book)
        {
            if (ReferenceEquals(book, null)) return 1;
            return string.Compare(Name, book.Name, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return "{/////  " + Name + " " + Author + " " + AgeOfPublication + "  /////}";
        }

        #endregion
    }
}
