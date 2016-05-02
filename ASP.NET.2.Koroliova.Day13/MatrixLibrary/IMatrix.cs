using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public interface IMatrix<T> 
    {

        int Dimention { get; }
        /// <summary>
        /// Enumerator
        /// </summary>
        /// <returns>Return the elements of matrix</returns>
        IEnumerable<T> GetMatrix();
        /// <summary>
        /// Indexator
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Column</param>
        /// <returns>Element (i,j)</returns>
        T this[int i, int j] { get; set; }
         string  GetStringMatrix();
    }
}
