using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electives
{
    /// <summary>
    /// Class Student. This type can subscribe on course.
    /// </summary>
    public class Student : IStudent
    {
        #region Fields

        private IDisposable unsubscriber;
        private ICourse course;
        private readonly string studentName;

        #endregion

        #region Ctror
        /// <summary>
        /// Ctor of class Student.
        /// </summary>
        /// <param name="fio">Students fio.</param>
        public Student(string fio)
        {
            studentName = fio;
        }
        #endregion

        #region Property
        /// <summary>
        /// Property returning student fio.
        /// </summary>
        public string StudentName { get { return studentName; } }

        #endregion

        #region Public Void Methods

        #region Non Virtual
        /// <summary>
        /// Method implements of interface method which subscribe student on the cours.
        /// </summary>
        /// <param name="myCourse">Cours</param>
        public void Subscribe(ICourse myCourse)
        {
            NLogger.Logger.Trace("Student want subscribe at cours " + myCourse.CoursInfo().CourseName + ". ...");
            try
            {
                unsubscriber = myCourse.Subscribe(this);
                course = myCourse;
            }
            catch (NullReferenceException e)
            {
                NLogger.Logger.Fatal("Null reference on cours." + e.Message);
                throw;
            }
            NLogger.Logger.Trace("Sibscribing finished.");
            NLogger.Logger.Info("You (" + studentName + ") subscribe at this course(" + myCourse.CoursInfo().CourseName + ").");
        }
        #endregion

        #region Virtual
        /// <summary>
        /// Method implements of interface method which unsubscribe student from the cours.
        /// </summary>
        public virtual void Unsubscribe()
        {
            NLogger.Logger.Info("You (" + studentName + ") unsubscribe from this course(" + course.CoursInfo().CourseName + ").");
            try
            {
                unsubscriber.Dispose();
            }
            catch (Exception e)
            {
                NLogger.Logger.Fatal("Unable to unsubscribe from the course"+e.Message);
                throw;
            }
        
        }
        /// <summary>
        /// Method implements method of interface IObserver  which completed that course finished.
        /// </summary>
        public virtual void OnCompleted()
        {
            NLogger.Logger.Info("You finished course.");
        }

        /// <summary>
        /// Method implements method of interface IObserver  which reports about error.
        /// </summary>
        /// <param name="error">Error</param>
        public virtual void OnError(Exception error)
        {
            NLogger.Logger.Fatal("Cours inform about FATAL ERROR."+error.Message);
        }
        /// <summary>
        /// Method implements method of interface IObserver  which reports that course start.
        /// </summary>
        /// <param name="value"></param>
        public virtual void OnNext(ICourseInfo value)
        {
            NLogger.Logger.Info("New course start: name of course - {1},  lector - {0}.", value.LectorName, value.CourseName);

        }
        #endregion

        #endregion
    }

}
