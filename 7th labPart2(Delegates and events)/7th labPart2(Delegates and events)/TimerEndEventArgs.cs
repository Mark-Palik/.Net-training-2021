using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7th_labPart2_Delegates_and_events_
{
    class TimerEndEventArgs : EventArgs
    {
        public string Name { get; set; }
        public TimerEndEventArgs(string name)
        {
            Name = name;
        }
    }
}
