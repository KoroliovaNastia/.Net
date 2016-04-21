using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electives
{
    public struct CourseInfo:ICourseInfo
    {
        private readonly string _lectorName;
        private readonly string _courseName;
        // private List<String> _students; 
        // private IDictionary<string, int?> _groupDictionary;
        // private marks

        public CourseInfo(string lectorName, string courseName)
        {
            _lectorName = lectorName;
            _courseName = courseName;
            // _students = default(List<string>);
            //     _groupDictionary= new Dictionary<string, int?>();
        }

        public string LectorName { get { return _lectorName; } }
        public string CourseName { get { return _courseName; } }
        //public List<string> Students
        //{ 
        //    get { return _students; }
        //}

        //public void AddStudent(string student)
        //{
        //    if(_students.Contains(student))
        //        throw new InvalidDataException();
        //    _students.Add(student);
        //}
    }
}
