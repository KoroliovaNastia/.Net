using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electives
{
    public class Course :ICourse
    {
        private ICourseInfo _course;
        
        private List<IStudent> _observers;

        public ILector Professor { get; private set; }

        public Course(ICourseInfo courseInfo)
        {
            _course = courseInfo;
            _observers = new List<IStudent>();
            
        }

        //public virtual IDisposable Subscribe(IStudent observer)
        //{
        //    if (!_observers.Contains(observer))
        //        _observers.Add(observer);

        //    return new Unsubscriber(_observers, observer);
        //}
        public IDisposable Subscribe(IStudent observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber(_observers, observer);
        }

        public IDisposable Subscribe(IObserver<ICourseInfo> observer)
        {
           return Subscribe((IStudent) observer);
        }
        public void AddObserver(IStudent student)
        {
            _observers.Add(student);
        }

        public void StartCours()
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(_course);
            }
        }

        public void FinishedCours()
        {
            foreach (var observer in _observers)
            {
                observer.OnCompleted();
            }
        }

        

        public ICourseInfo CoursInfo()
        {
            return _course;
        }

        public void GetMark(IStudent student)
        {
            if (_observers.Contains(student))
                if(Archive.Instance.GetMark(student, this)>0.0)
                NLogger.Logger.Info("Student " + student.StudentName + " received at the course '" + _course.CourseName + "' the mark :" +  Archive.Instance.GetMark(student, this));
            //return Professor.SetTheMark(student);
            // Archive.Dictionary();
        }

        
    }

}
