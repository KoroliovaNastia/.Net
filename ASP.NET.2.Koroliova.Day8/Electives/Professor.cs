using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electives
{
    public class Professor : ILector
    {
        private readonly string _professorName;
        private List<ICourse> _myCourses = new List<ICourse>();
        public List<ICourse> MyCourses
        {
            get { return _myCourses; }
        }

        public string ProfessorName
        {
            get { return _professorName; }
        }

        public Professor(string fio)
        {
            _professorName = fio;
        }

        public Professor(string fio, List<ICourse> courses)
        {
            _professorName = fio;
            _myCourses = courses;
        }

        public ICourse CreateCourse(string courseName)
        {
            if (courseName == null)
                throw new ArgumentNullException();
            Course course = new Course(new CourseInfo(_professorName, courseName));
            _myCourses.Add(course);
            NLogger.Logger.Info("Open new cours : " + courseName + ". Lector :"+_professorName+".");

            return course;
        }
        public void AddCours(ICourse course)
        {
            if (_myCourses.Contains(course))
                throw new InvalidOperationException("You already have this course.");
            NLogger.Logger.Info("Professor "+_professorName+" add new course in his collection. Course name :"+course.CoursInfo().CourseName+".");
            _myCourses.Add(course);
        }

        public double SetTheMark(IStudent student)
        {
            double mark = 9;
            return mark;
        }
    }
}
