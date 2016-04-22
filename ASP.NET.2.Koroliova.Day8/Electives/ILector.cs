using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electives
{
    /// <summary>
    /// Interface Lector
    /// </summary>
   public interface ILector
    {
       /// <summary>
       /// Method for setting mark of the student.
       /// </summary>
       /// <param name="student">Student.</param>
       /// <returns>Return mark.</returns>
        double SetTheMark(IStudent student);
    }
}
