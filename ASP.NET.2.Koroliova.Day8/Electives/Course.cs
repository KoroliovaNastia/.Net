using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electives
{
    /// <summary>
    /// Course.
    /// </summary>
    public class Course : ICourse
    {
        #region Fields

        private ICourseInfo course;

        private List<IStudent> observers;
        #endregion

        #region Property
        /// <summary>
        /// Return professor.
        /// </summary>
        public ILector Professor { get; private set; }

        #endregion

        #region Ctor
        public Course(ICourseInfo courseInfo)
        {
            course = courseInfo;
            observers = new List<IStudent>();

        }
        #endregion

        #region Methods
        /// <summary>
        /// Subscribe observer
        /// </summary>
        /// <param name="observer">Observer</param>
        /// <returns></returns>
        public IDisposable Subscribe(IStudent observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            else NLogger.Logger.Warn("This student already subscribe on course.");
            return new Unsubscriber(observers, observer);
        }

        public IDisposable Subscribe(IObserver<ICourseInfo> observer)
        {
            return Subscribe((IStudent)observer);
        }
        /// <summary>
        /// Add observer of course.
        /// </summary>
        /// <param name="student"></param>
        public void AddObserver(IStudent student)
        {
            try
            {
                if (student == null)
                {
                    NLogger.Logger.Fatal("Null reference on the student at adding observer.");
                }
                observers.Add(student);
            }
            catch (Exception e)
            {
                NLogger.Logger.Fatal("Course inform about FATAL ERROR" + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Alert to listener about starting cousre.
        /// </summary>
        public void StartCours()
        {
            NLogger.Logger.Trace("Course start, alert to listeners.");
            try
            {
                foreach (var observer in observers)
                {
                    observer.OnNext(course);
                }
            }
            catch (Exception e)
            {
                NLogger.Logger.Fatal("Course inform about FATAL ERROR" + e.Message);
                throw;
            }
        }
        /// <summary>
        /// Method for finishing course and listener alert.
        /// </summary>
        public void FinishedCours()
        {
            NLogger.Logger.Trace("Course finished, alert to listeners.");
            foreach (var observer in observers)
            {
                observer.OnCompleted();
            }
        }


        /// <summary>
        /// Return course
        /// </summary>
        /// <returns></returns>
        public ICourseInfo CoursInfo()
        {
            return course;
        }

        /// <summary>
        /// Return mark of student.
        /// </summary>
        /// <param name="student">Student</param>
        public void GetMark(IStudent student)
        {
            if (student == null)
                throw new NullReferenceException("student have null reference");
            if (observers.Contains(student))
                if (Archive.Instance.GetMark(student, this) > 0.0)
                    NLogger.Logger.Info("Student " + student.StudentName + " received at the course '" +
                                        course.CourseName + "' the mark :" + Archive.Instance.GetMark(student, this));


        }

        #endregion
    }

}
