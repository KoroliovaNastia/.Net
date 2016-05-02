using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MatrixLibrary.Matrix
{
    public class SquareMatrix<T> : IMatrix<T>
    {
        private readonly int dimention;
        private readonly T[,] coeff;
        protected event EventHandler<MatrixEventArgs> Message;
        /// <summary>
        /// Empty initialisation.
        /// </summary>
        public SquareMatrix()
        {
            coeff = new T[1, 1];
        }
        /// <summary>
        /// Initialise matrix using a two-dimensional array.
        /// </summary>
        /// <param name="matrix"></param>
        public SquareMatrix(T[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException();
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentOutOfRangeException();
            dimention = matrix.GetLength(0);
            coeff = matrix;
        }
        /// <summary>
        /// Property. Return dimention of the matrix.
        /// </summary>
        public int Dimention
        {
            get
            {
                if (coeff == null)
                    throw new ArgumentNullException();
                return dimention;
            }
        }
        /// <summary>
        /// Indexator
        /// </summary>
        /// <param name="i">Row.</param>
        /// <param name="j">Column</param>
        /// <returns>Element (i,j)</returns>
        public T this[int i, int j]
        {

            get
            {
                if ((i < 0 || j < 0) || (i > dimention || j > dimention))
                    throw new ArgumentOutOfRangeException();
                return coeff[i, j];
            }
            set
            {
                if ((i < 0 || j < 0) || (i > dimention || j > dimention))
                    throw new ArgumentOutOfRangeException();
                coeff[i, j] = value;
                OnElementChenges(new MatrixEventArgs("Element (i,j): (" + i + "," + j + ") changes in square matrix"));
            }
        }
        /// <summary>
        /// Method the string representation of the matrix
        /// </summary>
        /// <returns></returns>
        public string GetStringMatrix()
        {
            if (ReferenceEquals(coeff, null))
            {
                return "";
            }
            var result = new StringBuilder();
            for (var i = 0; i < coeff.GetLength(0); i++)
            {
                for (var j = 0; j < coeff.GetLength(1); j++)
                {
                    if (ReferenceEquals(coeff[i, j], null)) result.Append("null ");
                    else result.Append(coeff[i, j] + " ");
                }
                result.Append("\n");
            }
            return result.ToString();
        }
        /// <summary>
        /// Enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetMatrix()
        {
            foreach (var item in coeff)
            {
                yield return item;
            }
        }
        /// <summary>
        /// Event
        /// </summary>
        /// <param name="e"></param>
        private void OnElementChenges(MatrixEventArgs e)
        {
            if (Message != null) Message.Invoke(this, e);
        }


    }
}
