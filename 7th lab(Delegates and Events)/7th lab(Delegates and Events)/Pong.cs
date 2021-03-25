using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace _7th_lab_Delegates_and_Events_
{
    class Pong
    {
        public event EventHandler<int> PongEvent;
        public void OnReceivingBall(object sender, int e)
        {
            if (e > 20)
            {
                Console.WriteLine("Endgame");
            }
            e++;
            PongEvent(this, e);
        }
        public void Unsubscribe()
        {
            PongEvent = null;
        }
    }
}
