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
    public class Book : IPublication
    {
        #region Fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly string name;
        private readonly string author;
        private readonly int year;
        #endregion
        #region Ctor
        /// <summary>
        /// Ctor of book.
        /// </summary>
        /// <param name="name">Name of book.</param>
        /// <param name="author">Author of book</param>
        /// <param name="year">Year of book publication.</param>
        public Book(string name, string author, int year)
            
        {
            logger.Debug("Created new book :" + this);
            logger.Info("Created new book :" + this);
            this.name = name;
            this.author = author;
            this.year = year;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Overriding property of interface Publication, returning the name of book.
        /// </summary>
        public  string Name
        {
            get { return name; }
        }
        /// <summary>
        /// Overriding property of interface Publication, returning the author of book.
        /// </summary>
        public string Author
        {
            get { return author; }
        }
        /// <summary>
        /// Overriding property of interface Publication, returning the year of book publicate.
        /// </summary>
        public int Year
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
        ///// <summary>
        ///// Overriding method of base class Publication, selecting criterion.
        ///// </summary>
        ///// <param name="criterionName"></param>
        ///// <returns></returns>
        //public  dynamic Criterion(string criterionName)
        //{
        //    if ("name" == criterionName)
        //        return Name;
        //    if ("author" == criterionName)
        //        return Author;
        //    if ("year" == criterionName)
        //        return Year;
        //    return false;
        //}
        #endregion
    }
}
