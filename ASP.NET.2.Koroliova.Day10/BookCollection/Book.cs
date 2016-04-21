using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace BookCollection
{
    /// <summary>
    /// Class Book inherits abstract class Publication.
    /// </summary>
    public class Book : Publication
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        #region Ctor
        /// <summary>
        /// Ctor of book using ctor of base class.
        /// </summary>
        /// <param name="nameOfBook">Name of book.</param>
        /// <param name="author">Author of book</param>
        /// <param name="year">Year of book publication.</param>
        public Book(string nameOfBook, string author, int year)
            : base(nameOfBook, author, year)
        {
            logger.Debug("Created new book :" + this);
            logger.Info("Created new book :" + this);
        }

        #endregion

        #region Properties
        /// <summary>
        /// Overriding property of base class Publication, returning the name of book.
        /// </summary>
        public override string Name
        {
            get { return name; }
        }
        /// <summary>
        /// Overriding property of base class Publication, returning the author of book.
        /// </summary>
        public override string Author
        {
            get { return author; }
        }
        /// <summary>
        /// Overriding property of base class Publication, returning the year of book publicate.
        /// </summary>
        public override int Year
        {
            get { return year; }
        }

        #endregion
        /// <summary>
        /// Overriding method ToString.
        /// </summary>
        /// <returns></returns>
        #region Public Methods
        public override string ToString()
        {
            string info = name + ", " + author + ", " + year;
            return info;
        }
        /// <summary>
        /// Overriding method of base class Publication, selecting criterion.
        /// </summary>
        /// <param name="criterionName"></param>
        /// <returns></returns>
        public override dynamic Criterion(string criterionName)
        {
            if ("name" == criterionName)
                return Name;
            if ("author" == criterionName)
                return Author;
            if ("year" == criterionName)
                return Year;
            return false;
        }
        #endregion
    }
}
