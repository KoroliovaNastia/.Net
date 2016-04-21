using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCollection
{
    /// <summary>
    /// Abstract class prin edition.
    /// </summary>
    public abstract class Publication
    {
        #region Fields

        protected string name;
        protected string author;
        protected int year;

        #endregion

        #region Public Properties
        /// <summary>
        /// Property return the name of publication.
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// Property return the author of publication.
        /// </summary>
        public abstract string Author { get; }
        /// <summary>
        /// Property return the year of publication.
        /// </summary>
        public abstract int Year { get; }

        #endregion

        #region Ctor
        protected Publication(string name, string author, int year)
        {
            this.name = name;
            this.author = author;
            this.year = year;
        }
        #endregion
        /// <summary>
        /// Abstract method of selecting  of criterion.
        /// </summary>
        /// <param name="criterionName"></param>
        /// <returns></returns>
        public abstract dynamic Criterion(string criterionName);
    }
}
