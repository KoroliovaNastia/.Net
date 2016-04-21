using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookCollection
{
    /// <summary>
    /// Interface of library.
    /// </summary>
    interface ILibrary
    {
        /// <summary>
        /// Method of saving the library.
        /// </summary>
        void SaveLibrary();
        /// <summary>
        /// Method of loading the library.
        /// </summary>
        void LoadLibrary();
        /// <summary>
        /// Method of adding the book.
        /// </summary>
        /// <param name="book"></param>
        void AddBook(Publication book);
        /// <summary>
        /// Method of removing the book.
        /// </summary>
        /// <param name="book"></param>
        void RemoveBook(Publication book);
        /// <summary>
        /// Method of finding book on criterion.
        /// </summary>
        /// <param name="criterionName">Name of criterion</param>
        /// <param name="criterion">Criterion.</param>
        void FindByTag(string criterionName, dynamic criterion);
        /// <summary>
        /// Method of sorting library of book on criterion.
        /// </summary>
        /// <param name="criterion"></param>
        void SortBooksByTag(string criterion);

    }
}
