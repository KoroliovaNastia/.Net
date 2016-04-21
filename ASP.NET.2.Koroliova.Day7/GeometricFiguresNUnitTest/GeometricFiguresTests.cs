using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GeometricFigures;

namespace GeometricFiguresNUnitTest
{
    public class GeometricFiguresTests
    {
        [Test, TestCaseSource(typeof(FiguresFactoryClass), "CircleAreaCase")]
        public double FindAreaCircleTest(CoordPoint point,double radious)
        {
            Circle cr=new Circle(point,radious);
            return cr.Area();
        }

        [Test, TestCaseSource(typeof(FiguresFactoryClass), "CirclePerimeterCase")]
        public double FindPerimeterCircleTest(CoordPoint point, double radious)
        {
            Circle cr = new Circle(point, radious);
            return cr.Perimeter();
        }

        [Test, TestCaseSource(typeof(FiguresFactoryClass), "RectangleAreaCase")]
        public double FindAreaRectangleTest(CoordPoint[] points)
        {
            Rectangle rk=new Rectangle(points);
            return rk.Area();
        }

        [Test, TestCaseSource(typeof(FiguresFactoryClass), "RectanglePerimeterCase")]
        public double FindPerimeterRectangleTest(CoordPoint[] points)
        {
            Rectangle rk = new Rectangle(points);
            return rk.Perimeter();
        }

        [Test, TestCaseSource(typeof(FiguresFactoryClass), "TriangleAreaCase")]
        public double FindAreaTriangleTest(CoordPoint[] points)
        {
            Triangle tr = new Triangle(points);
            return tr.Area();
        }

        [Test, TestCaseSource(typeof(FiguresFactoryClass), "TrianglePerimeterCase")]
        public double FindPerimeterTriangleTest(CoordPoint[] points)
        {
            Triangle tr = new Triangle(points);
            return tr.Perimeter();
        }

        [Test, TestCaseSource(typeof(FiguresFactoryClass), "SquareAreaCase")]
        public double FindAreaSquareTest(CoordPoint[] points)
        {
            Square sq = new Square(points);
            return sq.Area();
        }

        [Test, TestCaseSource(typeof(FiguresFactoryClass), "SquarePerimeterCase")]
        public double FindPerimeterSquareTest(CoordPoint[] points)
        {
            Square sq = new Square(points);
            return sq.Perimeter();
        }
        public class FiguresFactoryClass
        {

            public static IEnumerable<TestCaseData> CircleAreaCase
            {
                get
                {
                    yield return new TestCaseData(new CoordPoint(2.0,3.0),4).Returns(Math.PI*16);
                    yield return new TestCaseData(new CoordPoint(0.0, 0.0), 0).Returns(0);
                    yield return new TestCaseData(new CoordPoint(0.0, 0.0), -3).Throws(typeof(ArgumentException));
                }
            }

            public static IEnumerable<TestCaseData> CirclePerimeterCase
            {
                get
                {
                    yield return new TestCaseData(new CoordPoint(0.0, 0.0), 4).Returns(2*Math.PI*4);

                }
            }
            public static IEnumerable<TestCaseData> RectangleAreaCase
            {
                get
                {
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(3, 2) }).Returns(2);
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(4, 1), new CoordPoint(4, 3), new CoordPoint(1, 3) }).Returns(6);
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(5, 1), new CoordPoint(4, 3), new CoordPoint(1, 3) }).Throws(typeof(ArgumentException));
                }
            }

            public static IEnumerable<TestCaseData> RectanglePerimeterCase
            {
                get
                {
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(3, 2) }).Returns(6);
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(4, 1), new CoordPoint(4, 3), new CoordPoint(1, 3) }).Returns(10);
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(5, 1), new CoordPoint(4, 3), new CoordPoint(1, 3) }).Throws(typeof(ArgumentException));

                }
            }
            public static IEnumerable<TestCaseData> TriangleAreaCase
            {
                get
                {
                    
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(4, 1), new CoordPoint(1, 3) }).Returns(3);
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1)}).Throws(typeof(ArgumentException));
                    yield return new TestCaseData(new CoordPoint[] {new CoordPoint(1, 1), new CoordPoint(4, 1), new CoordPoint(8, 1)}).Throws(typeof (ArgumentException));
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(1, 3), new CoordPoint(1, 2) }).Throws(typeof(ArgumentException));
                }
            }

            public static IEnumerable<TestCaseData> TrianglePerimeterCase
            {
                get
                {
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(5, 1), new CoordPoint(1, 4) }).Returns(12);
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1) }).Throws(typeof(ArgumentException));
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(2, 1), new CoordPoint(4, 1), new CoordPoint(8, 1) }).Throws(typeof(ArgumentException));
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(1, 5), new CoordPoint(1, 5) }).Throws(typeof(ArgumentException));
                }
            }
            public static IEnumerable<TestCaseData> SquareAreaCase
            {
                get
                {
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(2, 2) }).Returns(1);
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(3, 2) }).Throws(typeof(ArgumentException));
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(4, 1), new CoordPoint(4, 4), new CoordPoint(1, 4) }).Returns(9);
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(5, 1), new CoordPoint(4, 3), new CoordPoint(1, 3) }).Throws(typeof(ArgumentException));

                }
            }

            public static IEnumerable<TestCaseData> SquarePerimeterCase
            {
                get
                {
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(2, 2) }).Returns(4);
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(3, 2) }).Throws(typeof(ArgumentException));
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(4, 1), new CoordPoint(4, 4), new CoordPoint(1, 4) }).Returns(12);
                    yield return new TestCaseData(new CoordPoint[] { new CoordPoint(1, 1), new CoordPoint(5, 1), new CoordPoint(4, 3), new CoordPoint(1, 3) }).Throws(typeof(ArgumentException));

                }
            }
        }
       
    }
}
