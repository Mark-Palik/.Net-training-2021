using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7th_labPart2_Delegates_and_events_.ClassesForInterface
{
    class ClassWithMethods : ICutDownNotifier
    {
        public void Init(Timer timer)
        {
            timer.TimeLeft += OnTimeLeft;
            timer.TimerEnd += OnTimerEnd;
            timer.TimerStart += OnTimerStart;
        }
        public void Run(Timer timer)
        {
            timer.StartTimer();
        }
        public void OnTimerEnd(object sender, TimerEndEventArgs e)
        {
            Console.WriteLine($"{e.Name} has reached its end");
        }
        public void OnTimeLeft(object sender, TimeLeftEventArgs e)
        {
            Console.WriteLine($"{e.Time} second/s left");
        }
        public void OnTimerStart(object sender, TimerStartEventArgs e)
        {
            Console.WriteLine($"{e.Name} has started counting");
        }
    }
}
