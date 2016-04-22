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
    /// <summary>
    /// Archive for saving marks.
    /// </summary>
    public class Archive
    {
        #region Fields

        private static readonly string fileName;
        private static Dictionary<IStudent, Dictionary<ICourse, double>> dictionary;
        private static readonly Archive instance;
        #endregion
        #region Ctors
        ///// <summary>
        ///// Instance ctor.
        ///// </summary>
        //private Archive()
        //{
        //    fileName = "archive.xml";
        //}
        /// <summary>
        /// Static ctor.
        /// </summary>
        static Archive()
        {
            NLogger.Logger.Info("Archive craete.");
            dictionary = new Dictionary<IStudent, Dictionary<ICourse, double>>();
            instance = new Archive();
            NLogger.Logger.Info("File for marks create.");
            fileName = "archive.xml";
        }

        #endregion

        #region Property
        /// <summary>
        /// Property for returning archive
        /// </summary>
        public static Archive Instance
        {
            get { return instance; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Method for setting mark of student who listen this course in the dictionary and saving in the file.
        /// </summary>
        /// <param name="student">Student</param>
        /// <param name="course">Course</param>
        /// <param name="professor">Lector of the course</param>
        public void SetMark(IStudent student, ICourse course, Professor professor)
        {
            NLogger.Logger.Trace("Archive open");
            if (!dictionary.ContainsKey(student))
                dictionary.Add(student, new Dictionary<ICourse, double>());
            if (!dictionary[student].ContainsKey(course))
                dictionary[student].Add(course, professor.SetTheMark(student));
            try
            {
                NLogger.Logger.Trace("Trying to write mark at the file");
                using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(fileName)))
                {
                    writer.Write(student.StudentName + ": " + dictionary[student][course] + ".");
                }
            }
            catch (IOException e)
            {
                NLogger.Logger.Error("Error of writing. " + e.Message);
                throw;
            }
            catch (ObjectDisposedException e)
            {
                NLogger.Logger.Error("The stream is closed. " + e.Message);
                throw;
            }
            NLogger.Logger.Trace("Marks were setted and write.");
        }

        /// <summary>
        /// Method for getting mark of student who listen this course.
        /// </summary>
        /// <param name="student">Student</param>
        /// <param name="course">Course</param>
        /// <returns></returns>
        public double GetMark(IStudent student, ICourse course)
        {
            NLogger.Logger.Trace("Student : " + student.StudentName + " res the mark");
            if (!dictionary.ContainsKey(student))
            {
                NLogger.Logger.Warn("Studen " + student.StudentName + "not found in archive");
                return -1;
            }
            if (!dictionary[student].ContainsKey(course))
            {
                NLogger.Logger.Warn("Studen " + student.StudentName + "not subscribe on this course");
                return -1;
            }
            return dictionary[student][course];
        }
        #endregion
    }
}
