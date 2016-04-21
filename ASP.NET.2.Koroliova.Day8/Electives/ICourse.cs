using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electives
{
   public interface ICourse : IObservable<ICourseInfo>
    {
        void StartCours();
        void FinishedCours();
        IDisposable Subscribe(IStudent observer);
       ICourseInfo CoursInfo();
    }
}
