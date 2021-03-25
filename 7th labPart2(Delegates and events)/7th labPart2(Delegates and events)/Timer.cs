using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _7th_labPart2_Delegates_and_events_
{
    class Timer
    {
        private int Time;
        public string Name { get; set; }
        public event EventHandler<TimeLeftEventArgs> TimeLeft;
        public event EventHandler<TimerEndEventArgs> TimerEnd;
        public event EventHandler<TimerStartEventArgs> TimerStart;
        public Timer(int time, string name)
        {

            try
            {
                Time = time * 1000;
            }
            catch (OverflowException)
            {

                Console.WriteLine("Entered too big integer value");
            }
            Name = name;
            TimerEnd += (sender, e) => { Time = time * 1_000; };
        }
        public void StartTimer()
        {
            if (Time < 0)
            {
                Time = -Time;
            }
            int initialTime = Time;
            TimerStart(this, new TimerStartEventArgs(Name));
            while (Time > 0)
            {
                TimeLeft(this, new TimeLeftEventArgs(Time));
                Thread.Sleep(1000);
                Time -= 1000;
            }

            TimerEnd(this, new TimerEndEventArgs(Name));
            Unsubscribe();
            Time = initialTime;
        }
        private void Unsubscribe()
        {
            TimeLeft = null;
            TimerEnd = null;
            TimerStart = null;
        }
    }
}