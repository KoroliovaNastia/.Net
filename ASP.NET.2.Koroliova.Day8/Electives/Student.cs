using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electives
{
    public class Student : IStudent
    {
        private IDisposable _unsubscriber;
        private ICourse _course;
        private readonly string _studentName;

        public Student(string fio)
        {
            _studentName = fio;
        }
        public string StudentName { get { return _studentName; } }
        public  void Subscribe(ICourse course)
        {
            _unsubscriber = course.Subscribe(this);
            _course = course;
        }
        public virtual void Unsubscribe()
        {
            NLogger.Logger.Info("You ("+_studentName+") unsubscribe from this course("+_course.CoursInfo().CourseName+").");
            _unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            NLogger.Logger.Info("You finished course.");
        }
        public virtual void OnError(Exception error)
        { }

        public virtual void OnNext(ICourseInfo value)
        {
            NLogger.Logger.Info("New course start: name of course - {1},  lector - {0}.", value.LectorName, value.CourseName);
          
        }
    }

}
