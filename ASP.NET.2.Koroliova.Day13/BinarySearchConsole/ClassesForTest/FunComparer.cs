using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchConsole.ClassesForTest
{
    public class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return -Comparer<int>.Default.Compare(x, y);
        }
    }

    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return -Comparer<string>.Default.Compare(x, y);
        }
    }

    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point p1, Point p2)
        {
            return Comparer<double>.Default.Compare(Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y),
                Math.Sqrt(p2.X * p2.X + p2.Y * p2.Y));
        }
    }

    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book book1, Book book2)
        {
            if (book1 == null && book2 == null)
                return 0;
            else if (book1 == null)
                return -1;
            else
                return String.Compare(book1.Name, book2.Name, StringComparison.Ordinal);
        }
    }
    class FunComparer
    {
        
            public static int IntComparer(int a, int b)
            {
                return -Comparer<int>.Default.Compare(a, b);
            }

            public static int StringComparer(string str1, string str2)
            {
                return -Comparer<string>.Default.Compare(str1, str2);
            }

            public static int PointComparer(Point p1, Point p2)
            {
                return Comparer<double>.Default.Compare(Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y), Math.Sqrt(p2.X * p2.X + p2.Y * p2.Y));
            }

            public static int BookComparer(Book book1, Book book2)
        {
            if (book1 == null && book2 == null)
                return 0;
            else if (book1 == null)
                return -1;
            else
                return String.Compare(book1.Name, book1.Name, StringComparison.Ordinal);
        }
    }
}
