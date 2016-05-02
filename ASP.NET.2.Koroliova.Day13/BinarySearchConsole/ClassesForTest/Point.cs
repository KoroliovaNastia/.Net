using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchConsole
{
    public struct Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point(double x, double y):this()
        {
            if (double.IsNaN(x) || double.IsNaN(y) || double.IsInfinity(x) || double.IsInfinity(y))
                throw new ArgumentException("The coordinates of a point must be a numbers");
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return "{" + X + " " + Y + "}";
        }
    }
}
