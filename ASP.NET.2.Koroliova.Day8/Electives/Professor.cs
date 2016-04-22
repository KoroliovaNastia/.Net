using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electives
{
    /// <summary>
    /// Professor teaches courses 
    /// </summary>
    public class Professor : ILector
    {
        #region Fields

        private readonly string professorName;
        private List<ICourse> myCourses = new List<ICourse>();

        #endregion

        #region Properties
        /// <summary>
        /// Return all professor's courses.
        /// </summary>
        public List<ICourse> MyCourses
        {
            get { return myCourses; }
        }

        /// <summary>
        /// Return prefessor name.
        /// </summary>
        public string ProfessorName
        {
            get { return professorName; }
        }

        #endregion

        #region Ctors

        public Professor(string fio)
        {
            professorName = fio;
        }

        public Professor(string fio, List<ICourse> courses)
        {
            professorName = fio;
            myCourses = courses;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Professor create new cours.
        /// </summary>
        /// <param name="courseName">Course name.</param>
        /// <returns></returns>
        public ICourse CreateCourse(string courseName)
        {
            if (courseName == null)
                throw new ArgumentNullException();
            Course course = new Course(new CourseInfo(professorName, courseName));
            myCourses.Add(course);
            NLogger.Logger.Info("Open new cours : " + courseName + ". Lector :" + professorName + ".");

            return course;
        }

        /// <summary>
        /// Professor add new course.
        /// </summary>
        /// <param name="course">Course</param>
        public void AddCours(ICourse course)
        {
            if (myCourses.Contains(course))
                throw new InvalidOperationException("You already have this course.");
            NLogger.Logger.Info("Professor " + professorName + " add new course in his collection. Course name :" + course.CoursInfo().CourseName + ".");
            myCourses.Add(course);
        }

        /// <summary>
        /// Professor set mark student.
        /// </summary>
        /// <param name="student">Student.</param>
        /// <returns></returns>
        public double SetTheMark(IStudent student)
        {
            double mark = 9;
            return mark;
        }

        #endregion
    }
}
