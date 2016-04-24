using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Timer.Listeners
{
    interface IListener<T>
    {
        /// <summary>
        /// Subscribe on the event
        /// </summary>
        /// <param name="someEvent"></param>
        void Subscribe(T someEvent);
        /// <summary>
        /// Unsubscribe from the event
        /// </summary>
        /// <param name="someEvent"></param>
        void Unsubscribe(T someEvent);
    }
}
