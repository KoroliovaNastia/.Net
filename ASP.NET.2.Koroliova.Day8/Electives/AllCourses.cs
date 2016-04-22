using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electives
{
    /// <summary>
    /// List of all courses.
    /// </summary>
   public class AllCourses
    {
         private List<ICourse> _allCourses = new List<ICourse>();

       public AllCourses()
       {
           
       }
       public void AddCourse(ICourse course)
       {
          
           _allCourses.Add(course);
 
       }

    }
}
