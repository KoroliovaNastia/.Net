using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
 
  public  class TimeEventArgs:EventArgs
    {
        private  readonly string message;
      /// <summary>
      /// Ctor
      /// </summary>
      /// <param name="report">Save needed message</param>
        public TimeEventArgs(string report)
        {
            if(report==null)
                throw new ArgumentNullException();
            message = report;
        }
      /// <summary>
      /// Return message
      /// </summary>
        public string Message { get { return message; } }
    }
}
