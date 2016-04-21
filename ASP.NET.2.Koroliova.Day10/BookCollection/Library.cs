using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.CSharp.RuntimeBinder;
using NLog;
using NLog.Fluent;

namespace BookCollection
{
    /// <summary>
    /// Library of print edition
    /// </summary>
    public class Library : IEnumerable<Publication>, ILibrary
    {
        #region Fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private List<Publication> books = new List<Publication>();
        private readonly static string fileName;

        #endregion

        #region Cctor
        static Library()
        {
            logger.Info("Library create with name : Library.dat");
            fileName = "Library.dat";
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Method of interface of saving library.
        /// </summary>
        public void SaveLibrary()
        {
            logger.Debug("Begins saving library. ...");
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
                {
                    foreach (Publication book in books)
                    {
                        writer.Write(book.Name);
                        writer.Write(book.Author);
                        writer.Write(book.Year);
                    }

                }
            }
            catch (IOException e)
            {
                logger.Error("Error of writing. " + e.Message);
                throw;
            }
            catch (ObjectDisposedException e)
            {
                logger.Error("The stream is closed. " + e.Message);
                throw;
            }
            catch (Exception e)
            {
                logger.Fatal("I don't know why and what, but smth failed when writing" + e.Message);
            }
            logger.Debug("Saving library finished");
            logger.Info("Saved new library");
        }
        /// <summary>
        /// Mthod of interface of loading library. 
        /// </summary>
        public void LoadLibrary()
        {
            logger.Debug("Begins loading library. ...");
            if (File.Exists(fileName))
            {
                try
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        while (reader.PeekChar() > -1)
                        {
                            string name = reader.ReadString();
                            string author = reader.ReadString();
                            int year = reader.ReadInt32();
                            Publication book = new Book(name, author, year);
                            books.Add(book);
                        }
                    }
                }
                catch (IOException e)
                {
                    logger.Error("Error of reading. " + e.Message);
                    throw;
                }
                catch (ObjectDisposedException e)
                {
                    logger.Error("The stream is closed. " + e.Message);
                    throw;
                }
                catch (Exception e)
                {
                    logger.Fatal("I don't know why and what, but smth failed when reading" + e.Message);
                }
            }
            else
            {
                logger.Warn("File Lybrary.dat don't exist");
            }
            logger.Debug("Loading library finished");
            logger.Info("New Library saved");
        }
        /// <summary>
        /// Method of interface of adding new book at the library. 
        /// </summary>
        /// <param name="book">Book which we try add. </param>
        public void AddBook(Publication book)
        {
            logger.Debug("Begins adding new book. ...");
            if (book == null)
                throw new ArgumentNullException();
            if (books.Contains(book))
                throw new IOException();
            books.Add(book);
            logger.Debug("Adding library finished");
            logger.Info("Added new book : " + book);
        }
        /// <summary>
        /// Method of interface of removing book out  the library.
        /// </summary>
        /// <param name="book">Book which we try remove.</param>
        public void RemoveBook(Publication book)
        {
            logger.Debug("Begins removing book. ...");
            if (book == null)
                throw new ArgumentNullException("book");
            if (!books.Contains(book))
                throw new ArgumentException("Book not found");
            books.Remove(book);
            logger.Debug("Removing library finished");
            logger.Info("You removed book : " + book);
        }
        /// <summary>
        /// Method of interface of searching books on criterion.
        /// </summary>
        /// <param name="criterionName">Name of criterion.</param>
        /// <param name="criterion">Criterion.</param>
        public void FindByTag(string criterionName, dynamic criterion)
        {
            logger.Debug("Begins search for books on criterion. ...");
            if (criterionName == null)

                throw new ArgumentNullException();
            try
            {
                foreach (var book in books.FindAll(x => x.Criterion(criterionName) == criterion))
                {
                    logger.Debug("Find :" + book);
                }
            }
            catch (RuntimeBinderException e)
            {

                logger.Error("Your criterion does not satisfy the required type" + e.Message);
                throw;
            }
            logger.Debug("Searching book on criterion finished. ");

        }
        /// <summary>
        /// Method of interface of sorting books on criterion.
        /// </summary>
        /// <param name="criterion">Criterion.</param>
        public void SortBooksByTag(string criterion)
        {
            logger.Debug("Begins sorting books by criterion. ...");
            if (criterion == null)
                throw new ArgumentNullException("criterion");
            try
            {
                books.Sort(
                    delegate(Publication book1, Publication book2)
                    {
                        return book1.Criterion(criterion).CompareTo(book2.Criterion(criterion));
                    });
            }
            catch (Exception e)
            {
                logger.Fatal("I don't know why and what, but smth failed when sorting" + e.Message);
                throw;
            }
        }

        #endregion

        #region Enumerators
        /// <summary>
        /// Enumerator of publication.
        /// </summary>
        /// <returns>Return publication (in this case - book).</returns>
        public IEnumerator<Publication> GetEnumerator()
        {
            foreach (var book in books)
            {
                yield return book;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
