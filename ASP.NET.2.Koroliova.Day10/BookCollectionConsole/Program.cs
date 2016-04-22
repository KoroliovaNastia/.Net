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
            IPublication book2=new Book("Good side","Nerovnya Nataliya",2016);
            Book book3=new Book("Gobsek","Balsak",1974);

            Library library = new Library();
          
            Console.WriteLine("\nAdding books. ...");
            library.AddBook(book1);
            library.AddBook(book3);
            library.AddBook(book2);
            Console.WriteLine("\nSaving library. ....");
            library.SaveLibrary();
            Console.WriteLine("\nFinding all books with 2016 year of publication. ...");
            library.FindByTag(x=>x.Year==2016);
            Console.WriteLine("\nFinding all books with author :  Nerovnya Nataliya. ...");
            library.FindByTag(x => x.Author == "Nerovnya Nataliya");
            Console.WriteLine("\nRemove book when author Nerovnya Nataliya");
            library.RemoveBook(book2);
            Console.WriteLine("\nTry find book after it removing. ...");
            library.FindByTag(x=>x.Name=="Good side");

            Console.WriteLine("All books library : library. ...");
            foreach (var book in library)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("\nCreate new library : library2");
            Library library2=new Library();

            Console.WriteLine("Load library in new library2. ...");
            library2.LoadLibrary();

            Console.WriteLine("All books library : library2. ...");
            foreach (var book in library2)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("\nSort library2 on author. ...");
            library2.SortBooksByTag((x,y)=>x.Author.CompareTo(y.Author));

            Console.WriteLine("Sorting lirary2. ...");
            foreach (var book in library2)
            {
                Console.WriteLine(book);
            }
            Console.ReadKey();
        }
    }
}
