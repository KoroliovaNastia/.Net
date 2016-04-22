using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace GeometricFigures
{
    #region Interface
    /// <summary>
    /// Interface with methods  finding perimeter and area
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Method of finding  perimeter
        /// </summary>
        /// <returns></returns>
        double Perimeter();
        /// <summary>
        /// Method of finding  area
        /// </summary>
        /// <returns></returns>
        double Area();
    }
    #endregion
    #region Struct
    /// <summary>
    /// Struct of Point
    /// </summary>
    public struct CoordPoint
    {
        private readonly double x, y;

        public double X
        {
            get { return x; }
        }
        public double Y
        {
            get { return y; }
        }
        public CoordPoint(double x, double y)
        {
            if(Double.IsNaN(x)||Double.IsNaN(y)||Double.IsInfinity(x)||Double.IsInfinity(y))
                throw new ArgumentException();
            this.x = x;
            this.y = y;
        }


    }
    #endregion
    #region CircleClass
   
    public class Circle : IFigure
    {
        #region Fields
        private double x;
        private double y;
        private double radious;
        #endregion
        #region Ctors
        /// <summary>
        /// Default ctor
        /// </summary>
        public Circle()
        {
            x = default(double);
            y = default(double);
            radious = default(double);
        }
        /// <summary>
        /// Ctor with point of center
        /// </summary>
        /// <param name="coord">Point</param>
        public Circle(CoordPoint coord)
            : this()
        {
            x = coord.X;
            y = coord.Y;
        }
        /// <summary>
        /// Ctir with point of center and circle radious
        /// </summary>
        /// <param name="coord"></param>
        /// <param name="r"></param>
        public Circle(CoordPoint coord, double r)
            : this(coord)
        {
            if (r < 0)
                throw new ArgumentException();
            radious = r;
        }
        #endregion
        #region ImplemetingMethods
        /// <summary>
        ///  Method finding perimeter of Circle, implementation of interface method
        /// </summary>
        /// <returns></returns>
        public double Perimeter()
        {
            return 2 * Math.PI * radious;
        }
        /// <summary>
        /// Method finding area of Circle, implementation of interface method
        /// </summary>
        /// <returns></returns>
        public double Area()
        {
            return Math.PI * Math.Pow(radious, 2);
        }
        #endregion
    }

    #endregion
    #region Polygon
    /// <summary>
    /// Base class for figure, inherits interface IFigure
    /// </summary>
    public class Polygon : IFigure
    {
        #region Field
        /// <summary>
        /// List of points for polygon
        /// </summary>
        private readonly CoordPoint[] list;
        #endregion
        #region Ctors
        /// <summary>
        /// The default constructor
        /// </summary>
        public Polygon()
        {
            list = new CoordPoint[0];
        }
        /// <summary>
        /// Constructor which initializes N points
        /// </summary>
        /// <param name="n">Number of points</param>
        public Polygon(int n)
        {
            list = new CoordPoint[n];
        }

        /// <summary>
        /// Constructor with parameters - points of polygon
        /// </summary>
        /// <param name="list">Points</param>
        public Polygon(CoordPoint[] list)
        {
            if (list == null)
                throw new NullReferenceException();
            this.list = list;
        }
        #endregion
        #region VirtualMethods
        /// <summary>
        /// Virtual method perimeter implementation of interface method 
        /// </summary>
        /// <returns></returns>
        public virtual double Perimeter()
        {
            double p = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (i == list.Length - 1)
                    p += Math.Sqrt(Math.Pow(list[0].X - list[i].X, 2) + Math.Pow(list[0].Y - list[i].Y, 2));
                else
                    p += Math.Sqrt(Math.Pow(list[i + 1].X - list[i].X, 2) + Math.Pow(list[i + 1].Y - list[i].Y, 2));
            }
            return p;
        }

        /// <summary>
        /// Virtual method area implementation of interface method
        /// </summary>
        /// <returns></returns>
        public virtual double Area()
        {
            double s = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (i == list.Length - 1)
                    s += (list[i].X + list[0].X) * (list[i].Y - list[0].Y);
                else
                {
                    s += (list[i].X + list[i + 1].X) * (list[i].Y - list[i + 1].Y);
                }
            }

            return (1.0 / 2) * Math.Abs(s);
        }
        #endregion
    }
    #endregion
    #region TriangleClass
    /// <summary>
    /// Class Triangle inherits class Polynom
    /// </summary>
    public class Triangle : Polygon
    {
        #region Field
        /// <summary>
        /// Epsilon for double numbers
        /// </summary>
        private static readonly double Eps;
        #endregion
        #region Ctors
        /// <summary>
        /// The defaul instatnce constructor
        /// </summary>
        public Triangle()
            : base(3)
        {

        }
        /// <summary>
        /// The defaul static constructor
        /// </summary>
        static Triangle()
        {
            Eps = 0.000000001;
        }
        /// <summary>
        /// Constructor with parameters - points of triangle
        /// </summary>
        /// <param name="list">Points</param>
        public Triangle(CoordPoint[] list)
            : base(list)
        {
            if (list == null)
                throw new ArgumentNullException();
            if (list.Length != 3)
                throw new ArgumentException();
            if ((Math.Abs(list[0].X - list[1].X) + Math.Abs(list[0].X - list[2].X)) < Eps ||
                (Math.Abs(list[0].Y - list[1].Y) + Math.Abs(list[0].Y - list[2].Y)) < Eps)
                throw new ArgumentException();
        }
        #endregion
    }
    #endregion

    #region RectangleClass
    /// <summary>
    /// Class Rectangle inherits class Polygon
    /// </summary>
    public class Rectangle : Polygon
    {
        private CoordPoint[] points;
        private static readonly double Eps;
        /// <summary>
        /// The default static constructor
        /// </summary>
        #region Ctors
        static Rectangle()
        {
            Eps = 0.000000001;
        }
        /// <summary>
        /// The default instatnce constructor
        /// </summary>
        public Rectangle()
            : base(4)
        {
        }
        /// <summary>
        /// Constructor with parameters - points of rectangle
        /// </summary>
        /// <param name="list">Points</param>
        public Rectangle(CoordPoint[] list)
            : base(list)
        {
            if (list.Length > 4 || list.Length <= 1)
                throw new ArgumentOutOfRangeException();
            if (list.Length == 3)
                throw new ArgumentException();
            if (list == null)
                throw new ArgumentNullException();
            points = list;

            if (list.Length == 4)
                if ((Math.Abs(points[0].X - points[1].X) - Math.Abs(points[2].X - points[3].X)) > 0 ||
                    (Math.Abs(points[0].Y - points[1].Y) - Math.Abs(points[2].Y - points[3].Y)) > 0)
                    throw new ArgumentException();
        }
        #endregion
        #region OverrideMethods
        /// <summary>
        /// Override method perimeter of base class polygon
        /// </summary>
        /// <returns></returns>
        public override double Perimeter()
        {
            double p = 0;
            if (points.Length == 4)
                return base.Perimeter();

            if (points.Length == 2)
                if (Math.Abs(points[0].X - points[1].X) < Eps || Math.Abs(points[0].Y - points[1].Y) < Eps)
                    throw new ArgumentException();
                else
                {
                    p = 2 * (Math.Abs(points[0].X - points[1].X) + Math.Abs(points[0].Y - points[1].Y));
                }
            return p;


        }
        /// <summary>
        /// Override method area of base class polygon
        /// </summary>
        /// <returns></returns>
        public override double Area()
        {
            if (points.Length == 4)
                return base.Area();
            double s = 0;
            if (points.Length == 2)
                if (Math.Abs(points[0].X - points[1].X) < Eps || Math.Abs(points[0].Y - points[1].Y) < Eps)
                    throw new ArgumentException();
                else
                {
                    s = Math.Abs(points[0].X - points[1].X) * Math.Abs(points[0].Y - points[1].Y);
                }
            return s;
        }
        #endregion
    }
    #endregion
    #region SquareClass
    /// <summary>
    /// Class square inherits class Rectangle
    /// </summary>
    public class Square : Polygon
    {
        private CoordPoint[] points;
        private static readonly double Eps;
        /// <summary>
        /// The default static constructor
        /// </summary>
        #region Ctors
        static Square()
        {
            Eps = 0.000000001;
        }
        /// <summary>
        /// The default constructor
        /// </summary>
        public Square():base(4)
        {
        }
        /// <summary>
        /// Constructor with parameter - list points 
        /// </summary>
        /// <param name="list">Points</param>
        public Square(CoordPoint[] list)
            : base(list)
        {
            if (list.Length == 2)
                if (Math.Abs(Math.Abs(list[0].X - list[1].X) - Math.Abs(list[0].Y - list[1].Y)) > 0)
                    throw new ArgumentException();
            points = list;
        }
        #endregion
        #region OverrideMethods
        /// <summary>
        /// Override method perimeter of base class square
        /// </summary>
        /// <returns></returns>
        public override double Perimeter()
        {
            double p = 0;
            if (points.Length == 4)
                return base.Perimeter();

            if (points.Length == 2)
                if (Math.Abs(Math.Abs(points[0].X - points[1].X) - Math.Abs(points[0].Y - points[1].Y))>Eps)
                    throw new ArgumentException();
                else
                {
                    p = 4 * (Math.Abs(points[0].X - points[1].X));
                }
            return p;


        }
        /// <summary>
        /// Override method area of base class square
        /// </summary>
        /// <returns></returns>
        public override double Area()
        {
            if (points.Length == 4)
                return base.Area();
            double s = 0;
            if (points.Length == 2)
                if (Math.Abs(Math.Abs(points[0].X - points[1].X) - Math.Abs(points[0].Y - points[1].Y)) > Eps)
                    throw new ArgumentException();
                else
                {
                    s = Math.Pow(Math.Abs(points[0].X - points[1].X),2);
                }
            return s;
        }
        #endregion
    }
    #endregion
}
