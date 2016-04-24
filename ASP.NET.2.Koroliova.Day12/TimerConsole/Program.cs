using System;
using System.Timers;
using System.Globalization;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Timer;
using Timer.Listeners;


namespace TimerConsole
{
    class Program
    {
        
      
        static void Main(string[] args)
        {
            var timer=new Clock();
            var listener1=new Listener1();
            var listener2=new Listener2();
            listener1.Subscribe(timer);
            listener2.Subscribe(timer);

            TimeSpan interval=new TimeSpan(0,0,0,20);
            Console.WriteLine("All listeners (listener1 and listener2) subscribe.");
            Console.WriteLine("\nTime of delay:"+interval.Seconds+" seconds. ");
            timer.StartTimer(interval);
            Thread.Sleep(2000);
            Console.WriteLine("\n Liestener2 unsubscribe");
            interval=new TimeSpan(0,0,0,30);
            listener2.Unsubscribe(timer);
            Console.WriteLine("\nTime of delay:" + interval.Seconds + " seconds. ");
            timer.StartTimer(interval);

            Console.Read();
        }
    }
}
