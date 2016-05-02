using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class MatrixEventArgs:EventArgs
    {
        private readonly string message;
        
      /// <summary>
      /// Ctor
      /// </summary>
      /// <param name="report">Save needed message</param>
        public MatrixEventArgs(string report)
        {
            if(report==null)
                throw new ArgumentNullException("report");
            message = report;
        }
      /// <summary>
      /// Return message
      /// </summary>
        public string Message { get { return message; } }

    }
}
