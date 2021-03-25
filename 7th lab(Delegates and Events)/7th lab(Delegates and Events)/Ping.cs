using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7th_lab_Delegates_and_Events_
{
    class Ping
    {
        
        public event EventHandler<int> PingEvent;
        public void OnReceivingBall(object sender, int e)
        {
            if (e > 20)
            {
                Console.WriteLine("Endgame");
                return;
            }
            Console.WriteLine("Ping received pong");
            e++;
            PingEvent(this,e);
        }
        public void RunTheGame()
        {
            PingEvent(this, 0);
        }
        public void Unsubscribe()
        {
            PingEvent = null;
        }
    }
}
