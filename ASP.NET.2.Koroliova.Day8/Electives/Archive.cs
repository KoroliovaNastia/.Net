using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using System.IO;
using System.Runtime.Serialization;

namespace Electives
{
  public  class Archive
    {
        private const string FileName = "archive.xml";
        private static Dictionary<IStudent, Dictionary<ICourse, double>> _dictionary;
        private static readonly Archive _instance = new Archive();
        private Archive()
        {
            NLogger.Logger.Info("Archive open");
            _dictionary = new Dictionary<IStudent, Dictionary<ICourse, double>>();
        }

        public static Archive Instance
        {
            get { return _instance; }
        }
        public void SetMark(IStudent student, ICourse course, Professor professor)
        {
            NLogger.Logger.Trace("Archive open");
            if (!_dictionary.ContainsKey(student))
            _dictionary.Add(student,new Dictionary<ICourse, double>());
            if (!_dictionary[student].ContainsKey(course))
                _dictionary[student].Add(course, professor.SetTheMark(student));
        }

        public double GetMark(IStudent student, ICourse course)
        {
            NLogger.Logger.Trace("Student : "+student.StudentName+" res the mark");
            if (!_dictionary.ContainsKey(student))
            {
                NLogger.Logger.Warn("Studen "+student.StudentName+"not found in archive");
                return -1;
            }
            if (!_dictionary[student].ContainsKey(course))
            {
                NLogger.Logger.Warn("Studen " + student.StudentName + "not subscribe on this course");
                return -1;
            }
            return _dictionary[student][course];
        }
    }
}
