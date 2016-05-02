using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLibrary.Matrix;
using MatrixLibrary;

namespace ConsoleMatrix
{
    class Program
    {
        private static void MatrixElemChanged(object sender, MatrixEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        static void Main(string[] args)
        {
            int[,] coeff={{1,2,3},{4,5,6},{7,8,9}};
            int[,] coeff2 = {{1,0,0}, {0,1,0}, {0,0,1}};
            IMatrix<int> matrixSq = new SquareMatrix<int>(coeff);
            DiagonalMatrix<int> matrixD = new DiagonalMatrix<int>(coeff2);
            IMatrix<int> matrix = matrixSq.AddMatrix(matrixD);
            Console.WriteLine( matrix.GetStringMatrix());


            string[,] str1={{"H","i"},{"Y","O"}};
            string[,] str2 = {{"Is",null}, {null,"strange"}};
            SquareMatrix<string> strSq=new SquareMatrix<string>(str1);
            DiagonalMatrix<string> strD=new DiagonalMatrix<string>(str2);
            IMatrix<string> strMatrix = strD.AddMatrix(strSq);
            foreach (var temp in strMatrix.GetMatrix())
            {
                Console.Write(temp+" ");
            }
            double[,] coeff3 = {{1,2,3}, {2,1,4}, {3,4,1}};
            SymmetricMatrix<double> matrixSum=new SymmetricMatrix<double>(coeff3);
            Console.ReadKey();
        }
    }
}
