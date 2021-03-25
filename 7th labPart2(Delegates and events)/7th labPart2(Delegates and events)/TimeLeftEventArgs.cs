using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7th_labPart2_Delegates_and_events_
{
    class TimeLeftEventArgs : EventArgs
    {
        public int Time { get; set; }
        public TimeLeftEventArgs(int time)
        {
            Time = time / 1000;
        }
    }
}
