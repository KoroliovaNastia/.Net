using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electives
{
   public interface ICourseInfo
    {
        string LectorName { get; }
        string CourseName { get; }
    }
}
