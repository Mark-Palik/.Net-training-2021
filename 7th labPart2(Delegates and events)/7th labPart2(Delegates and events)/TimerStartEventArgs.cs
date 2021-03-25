using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7th_labPart2_Delegates_and_events_
{
    class TimerStartEventArgs : EventArgs
    {
        public string Name { get; set; }
        public TimerStartEventArgs(string name)
        {
            Name = name;
        }
    }
}
