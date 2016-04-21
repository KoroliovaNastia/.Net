using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electives
{
    public interface IStudent:IObserver<ICourseInfo>
    {
         string StudentName { get; }

        void Subscribe(ICourse cours);
        void Unsubscribe();
    }
}
