using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polinom;

namespace PolinomTest
{
    [TestClass]
    public class CreatePolinomClassTest
    {
        [TestMethod]
        public void CreatePolinomTest()
        {
            //Arange
            CreatePolinom polinom = new CreatePolinom();
            double[] coeff = {1, 2, 3, 4, 5};
            //Act
            polinom=new CreatePolinom(coeff);
            int degree = polinom.Degree;
            //Assert
            Assert.AreEqual(4,degree);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePolinomNullExceptionTest()
        {
            //Arange
            CreatePolinom polinom = new CreatePolinom();
            //Act
            polinom = new CreatePolinom(null);
            int degree = polinom.Degree;
            //Assert
            Assert.AreEqual(0, degree);
        }
        [TestMethod]
        public void SummPolinomTest()
        {
            //Arange
            CreatePolinom polinom1 = new CreatePolinom(new double[]{ 1, 2, 3, 4, 5 });
            CreatePolinom polinom2 = new CreatePolinom(new double[] { 0, 0, 0, 0, 0,1 });
            //Act
            polinom1 = polinom1 + polinom2;
            int degree = polinom1.Degree;
            //Assert
            Assert.AreEqual(5, degree);
        }
        [TestMethod]
        public void DiffPolinomTest()
        {
            //Arange
            CreatePolinom polinom1 = new CreatePolinom(new double[]{ 1, 2, 3, 4, 5 });
            CreatePolinom polinom2 = new CreatePolinom(new double[] {0, 0, 0, 4, 5});
            //Act
            polinom1 = polinom1 - polinom2;
            int degree = polinom1.Degree;
            //Assert
            Assert.AreEqual(2, degree);
        }
        [TestMethod]
        public void MultPolinomTest()
        {
            //Arange
            CreatePolinom polinom1 = new CreatePolinom(new double[] { 1.0, 2 });
            CreatePolinom polinom2 = new CreatePolinom(new double[] { 0, 2.5, 1, 2 });
            //Act
            polinom1 = polinom1*polinom2;
            int degree = polinom1.Degree;
            //Assert
            Assert.AreEqual(4, degree);
        }
    }
}
