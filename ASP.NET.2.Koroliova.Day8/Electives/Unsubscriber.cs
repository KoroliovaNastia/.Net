using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electives
{
    class Unsubscriber : IDisposable
    {
        private readonly List<IStudent> _observers;
        private readonly IStudent _observer;

        public Unsubscriber(List<IStudent> observers, IStudent observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null)
            {
                NLogger.Logger.Trace("Student unsubscribe");
                _observers.Remove(_observer);
                
            }

        }
    }
}
