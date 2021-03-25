using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7th_lab_Delegates_and_Events_
{
    class Arrival_Info
    {
        public string trainName { get; set; }
        public DateTime arrivalTime { get; set; }
        public int wagonNum { get; set; }
        public int seatNum { get; set; }
        public Arrival_Info(string nameOfTrain, DateTime arrTime, int wNum, int sNum)
        {
            trainName = nameOfTrain;
            arrivalTime = arrTime;
            wagonNum = wNum;
            seatNum = sNum;
        }
    }
}
