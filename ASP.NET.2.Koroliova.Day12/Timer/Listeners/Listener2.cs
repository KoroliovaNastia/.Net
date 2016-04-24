using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer.Listeners
{
    /// <summary>
    /// Second listener
    /// </summary>
    public class Listener2:IListener<Clock>
    {
       /// <summary>
       /// Listener subcsribe on the event
       /// </summary>
       /// <param name="someEvent">Event</param>
        public void Subscribe(Clock someEvent)
        {
            if(someEvent==null)
                throw new ArgumentNullException();
            someEvent.Message += Listener2Timer;
        }
        /// <summary>
        /// Listener reaction to the event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="eventArgs">Message</param>
        public void Listener2Timer(Object sender, TimeEventArgs eventArgs)
        {
            Console.WriteLine("Listener2 received notice: "+eventArgs.Message);
        }
        /// <summary>
        /// Listenr unsubscribe from the event
        /// </summary>
        /// <param name="someEvent">Event</param>
        public void Unsubscribe(Clock someEvent)
        {
            if (someEvent == null)
                throw new ArgumentNullException();
            someEvent.Message -= Listener2Timer;
        }
    }
}
