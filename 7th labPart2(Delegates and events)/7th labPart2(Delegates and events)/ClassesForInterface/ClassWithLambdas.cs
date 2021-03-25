using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7th_labPart2_Delegates_and_events_.ClassesForInterface
{
    class ClassWithLambdas : ICutDownNotifier
    {
        public void Init(Timer timer)
        {
            timer.TimeLeft += (sender, e) => { Console.WriteLine($"{e.Time} second/s left"); };
            timer.TimerEnd += (sender, e) => { Console.WriteLine($"{e.Name} has reached its end"); };
            timer.TimerStart += (sender, e) => { Console.WriteLine($"{e.Name} has started counting"); };
        }
        public void Run(Timer timer)
        {
            timer.StartTimer();
        }
    }
}
