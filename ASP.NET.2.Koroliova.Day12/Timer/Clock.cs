using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Diagnostics;

namespace Timer
{
    public class Clock
    {
        /// <summary>
        /// Event
        /// </summary>
        public event EventHandler<TimeEventArgs> Message; 
        /// <summary>
        /// Function of the triggering event
        /// </summary>
        /// <param name="e"></param>
        private void OnMessage(TimeEventArgs e)
        {
            if (Message != null) Message(this, e);
            
        }
        /// <summary>
        /// Function timer 
        /// </summary>
        /// <param name="time">Time</param>
        public void StartTimer(TimeSpan time)
        {
            if(time<TimeSpan.Zero)
                throw new ArgumentNullException();
            Thread.Sleep(time);
            OnMessage(new TimeEventArgs("Time is over =)"));
        }

    }
}
