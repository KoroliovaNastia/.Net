using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchConsole.ClassesForTest;
using BinarySearchLibrary;

namespace BinarySearchConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] massInt = {23, 76, -1, 8, 3, 80, 45, 11, 34};
            string[] massString = {"Red", "Orange", "Yellow", "Green", "Blue", "Viola"};
            Book[] books = new[]
            {
                new Book("Probability theory","Lasakovich",2011), 
                new Book("Samurai - Japanese military class","Spevakovsky",1981), 
                new Book("C# 5.0 in a Nutshell, 5th Edition","Albahari",2012), 
                new Book("Psychology of the influence","Chaldin",2001) 
            };
            Point[] points = new Point[]
            {
                new Point (1,2),
                new Point (2,1),
                new Point (5,7),
                new Point (5,2),
                new Point (4,3),
                new Point (1,7),

            };
            BinaryTree<int> threeInts=new BinaryTree<int>(massInt);
            BinaryTree<string> threeString = new BinaryTree<string>(massString);
            BinaryTree<Book> threeBook = new BinaryTree<Book>(books);
            BinaryTree<Point> threePoints = new BinaryTree<Point>(points, new PointComparer());

            IEnumerable<int> intInorder = threeInts.InOrderEnum();
            IEnumerable<int> intPreorder = threeInts.PreOrderEnum();
            IEnumerable<int> intPostorder = threeInts.PostOrderEnum();
            Console.WriteLine("\nInt mass inorder:");
            foreach (var item in intInorder)
                Console.Write(item + " ");
            Console.WriteLine("\nInt mass preorder:");
            foreach (var item in intPreorder)
                Console.Write(item + " ");
            Console.WriteLine("\nInt mass postorder:");
            foreach (var item in intPostorder)
                Console.Write(item + " ");
            Console.WriteLine();

            IEnumerable<string> stringInorder = threeString.InOrderEnum();
            IEnumerable<string> stringPreorder = threeString.PreOrderEnum();
            IEnumerable<string> stringPostorder = threeString.PostOrderEnum();
            Console.WriteLine("\nString mass inorder:");
            foreach (var item in stringInorder)
                Console.Write(item + " ");
            Console.WriteLine("\nString mass preorder:");
            foreach (var item in stringPreorder)
                Console.Write(item + " ");
            Console.WriteLine("\nString mass postorder:");
            foreach (var item in stringPostorder)
                Console.Write(item + " ");
            Console.WriteLine();

            IEnumerable<Book> bookInorder = threeBook.InOrderEnum();
            IEnumerable<Book> bookPreorder = threeBook.PreOrderEnum();
            IEnumerable<Book> bookPostorder = threeBook.PostOrderEnum();
            Console.WriteLine("\nBooks mass inorder:");
            foreach (var item in bookInorder)
                Console.Write(item + " ");
            Console.WriteLine("\nBooks mass preorder:");
            foreach (var item in bookPreorder)
                Console.Write(item + " ");
            Console.WriteLine("\nBooks mass postorder:");
            foreach (var item in bookPostorder)
                Console.Write(item + " ");
            Console.WriteLine();

            IEnumerable<Point> pointInorder = threePoints.InOrderEnum();
            IEnumerable<Point> pointPreorder = threePoints.PreOrderEnum();
            IEnumerable<Point> pointPostorder = threePoints.PostOrderEnum();
            Console.WriteLine("\nPoints mass inorder:");
            foreach (var item in pointInorder)
                Console.Write(item + " ");
            Console.WriteLine("\nPoints mass preorder:");
            foreach (var item in pointPreorder)
                Console.Write(item + " ");
            Console.WriteLine("\nPoints mass postorder:");
            foreach (var item in pointPostorder)
                Console.Write(item + " ");
            Console.WriteLine();

            Console.WriteLine(threePoints.Find(new Point(1, 2)));
            Console.WriteLine("\n Remove 80 from int mass: ");
            threeInts.Remove(80);
            intInorder = threeInts.InOrderEnum();
            intPostorder = threeInts.PostOrderEnum();
            intPreorder = threeInts.PreOrderEnum();
            Console.WriteLine("\nPoints mass inorder:");
            foreach (var item in intInorder)
                Console.Write(item + " ");
            Console.WriteLine("\nPoints mass preorder:");
            foreach (var item in intPreorder)
                Console.Write(item + " ");
            Console.WriteLine("\nPoints mass postorder:");
            foreach (var item in intPostorder)
                Console.Write(item + " ");
            Console.ReadKey();
        }
    }
}
