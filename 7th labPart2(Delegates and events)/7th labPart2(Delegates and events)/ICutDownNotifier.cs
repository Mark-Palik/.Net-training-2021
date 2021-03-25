using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7th_labPart2_Delegates_and_events_
{
    interface ICutDownNotifier
    {
        void Init(Timer timer);
        void Run(Timer timer);
    }
}
