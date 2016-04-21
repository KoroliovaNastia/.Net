using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCollection;

namespace BookCollectionConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1=new Book("Don't sterve","I",2016);
            Publication book2=new Book("Good side","Nerovnya Nataliya",2016);
            Book book3=new Book("Gobsek","Balsak",1974);

            Library library = new Library();
            library.AddBook(book1);
            library.AddBook(book3);
            library.AddBook(book2);
            library.SaveLibrary();
            library.FindByTag("year",1999);
            library.FindByTag("author","Nerovnya Nataliya");
            library.RemoveBook(book2);
            library.FindByTag("name","Good side");
            foreach (var book in library)
            {
                Console.WriteLine(book);
            }
            Library library2=new Library();
            library2.LoadLibrary();
            foreach (var book in library2)
            {
                Console.WriteLine(book);
            }
            library2.SortBooksByTag("author");
            foreach (var book in library2)
            {
                Console.WriteLine(book);
            }
            Console.ReadKey();
        }
    }
}
