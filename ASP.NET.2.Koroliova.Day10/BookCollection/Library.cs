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
    public class Library : IEnumerable<IPublication>, ILibrary
    {
        #region Fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private List<IPublication> books = new List<IPublication>();
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
                    foreach (IPublication book in books)
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
            if (!File.Exists(fileName))
            {
                logger.Warn("File Library.dat don't exist");
                return;
            }

            try
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        while (reader.PeekChar() > -1)
                        {
                            string name = reader.ReadString();
                            string author = reader.ReadString();
                            int year = reader.ReadInt32();
                            IPublication book = new Book(name, author, year);
                            books.Add(book);
                        }
                    }
                }
                catch (IOException e)
                {
                    logger.Fatal("Error of reading. " + e.Message);
                    throw;
                }
                catch (ObjectDisposedException e)
                {
                    logger.Fatal("The stream is closed. " + e.Message);
                    throw;
                }
                catch (Exception e)
                {
                    logger.Fatal("Smth failed when reading" + e.Message);
                    throw;
                }
            
            logger.Debug("Loading library finished");
            logger.Info("New Library saved");
        }
        /// <summary>
        /// Method of interface of adding new book at the library. 
        /// </summary>
        /// <param name="book">Book which we try add. </param>
        public void AddBook(IPublication book)
        {
            logger.Debug("Begins adding new book. ...");
            if (book == null)
            {
                logger.Error("Null reference to a book in adding");
                throw new ArgumentNullException();
            }
            if (books.Contains(book))
            {
                logger.Error("This book don't found at the library");
                throw new IOException();
            }
            books.Add(book);
            logger.Debug("Adding library finished");
            logger.Info("Added new book : " + book);
        }
        /// <summary>
        /// Method of interface of removing book out  the library.
        /// </summary>
        /// <param name="book">Book which we try remove.</param>
        public void RemoveBook(IPublication book)
        {
            logger.Debug("Begins removing book. ...");
            if (book == null)
            {
                logger.Error("Null reference to a book in removing");
                throw new ArgumentNullException("book");
            }
            if (!books.Contains(book))
            {
                logger.Error("This book don't found at the library");
                throw new ArgumentException();
            }
            books.Remove(book);
            logger.Debug("Removing library finished");
            logger.Info("You removed book : " + book);
        }
        /// <summary>
        /// Method of interface of searching books on criteria.
        /// </summary>
        /// <param name="predicate">Anonymus method neede finding </param>
        public void FindByTag(Predicate<IPublication> predicate)
        {
            logger.Debug("Begins search for books on criterion. ...");
            if (predicate == null)
            {
                logger.Error("Null reference to a predicate");
                throw new ArgumentNullException();
            }
            try
            {
                List<IPublication> list=new List<IPublication>();
                foreach (var book in books.FindAll(predicate))
                {
                    logger.Debug("Find :" + book);
                    list.Add(book);
                }
                if (list.Capacity == 0)
                    logger.Debug("Books not found");
            }
            catch (Exception e)
            {

                logger.Error("Method FindByTag work not correctly " + e.Message);
                throw;
            }
            logger.Debug("Searching book on criterion finished. ");

        }
        /// <summary>
        /// Method of interface of sorting books on criteria.
        /// </summary>
        /// <param name="comparer">Comparer.</param>
        public void SortBooksByTag(Comparison<IPublication>  comparer)
        {
            logger.Debug("Begins sorting books by criterion. ...");
            if (comparer == null)
            {
                logger.Fatal("Null reference to a comparer");
                throw new ArgumentNullException("comparer");
            }
            try
            {
                books.Sort(comparer);
            }
            catch (Exception e)
            {
                logger.Fatal("Smth failed when sorting" + e.Message);
                throw;
            }
        }

        #endregion

        #region Enumerators
        /// <summary>
        /// Enumerator of publication.
        /// </summary>
        /// <returns>Return publication (in this case - book).</returns>
        public IEnumerator<IPublication> GetEnumerator()
        {
            return books.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
