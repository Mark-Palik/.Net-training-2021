using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7th_labPart2_Delegates_and_events_.ClassesForInterface
{
    class ClassWithAnonymousMethods : ICutDownNotifier
    {
        public void Init(Timer timer)
        {
            timer.TimeLeft += delegate (object sender, TimeLeftEventArgs e) { Console.WriteLine($"{e.Time} second/s left"); };
            timer.TimerEnd += delegate (object sender, TimerEndEventArgs e) { Console.WriteLine($"{e.Name} has reached its end"); };
            timer.TimerStart += delegate (object sender, TimerStartEventArgs e) { Console.WriteLine($"{e.Name} has started counting"); };
        }
        public void Run(Timer timer)
        {
            timer.StartTimer();
        }
    }
}
