using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7th_lab_Delegates_and_Events_
{
    class Train
    {
        public delegate void MyDel(string info, Arrival_Info e);
        public event MyDel Arrival;
        public string trainName { get; set; }
        public DateTime arrivalTime { get; set; }
        public int wagonNum { get; set; }
        public int seatNum { get; set; }
        public Train(string tName, DateTime date, int wNum, int sNum)
        {
            arrivalTime = DateTime.Now;
            trainName = tName;
            wagonNum = wNum;
            seatNum = sNum;
        }
        public void Arrived()
        {
            Arrival?.Invoke($"Train is arriving: ",new Arrival_Info(trainName, arrivalTime,wagonNum, seatNum));
        }
    }
}
