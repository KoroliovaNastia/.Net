using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electives
{
    /// <summary>
    /// Interface which inherits interface IObserver.
    /// </summary>
    public interface IStudent:IObserver<ICourseInfo>
    {
        /// <summary>
        /// Return student name.
        /// </summary>
         string StudentName { get; }

        /// <summary>
        /// Subscribe on course.
        /// </summary>
        /// <param name="cours"></param>
        void Subscribe(ICourse cours);
        /// <summary>
        /// Unsubscribe from the course.
        /// </summary>
        void Unsubscribe();
    }
}
