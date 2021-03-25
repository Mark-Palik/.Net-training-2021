using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7th_lab_Delegates_and_Events_
{
    class Program
    {
        private static string data1 = "Hello world";
        private static int data2 = 43;
        static void Main(string[] args)
        {
            Console.WriteLine("===================1st part===============");
            Func<Action<object>, float, float> func = Method1;
            func += Method2;
            Console.WriteLine("Using PrintData1 method:");
            Console.WriteLine(func(PrintData1, 25.0f));
            Console.WriteLine();
            Console.WriteLine("Using PrintData2 method:");
            Console.WriteLine(func(PrintData2, 39999.0f));
            Console.WriteLine("===================2nd part===============");
            Ping ping = new Ping();
            Pong pong = new Pong();
            ping.PingEvent += pong.OnReceivingBall;
            pong.PongEvent += ping.OnReceivingBall;
            ping.RunTheGame();
            ping.Unsubscribe();
            pong.Unsubscribe();
            Console.WriteLine("===================3rd part===============");
            Train tr = new Train("Tommy", DateTime.Now, 4, 6);
            tr.Arrival += TrainArrivalHandler;
            tr.Arrived();
            Console.ReadLine();
        }
        public static void TrainArrivalHandler(string str, Arrival_Info e)
        {
            Console.WriteLine(str + $"\nTrain name :{e.trainName} \nArrival Time :{e.arrivalTime} \nWagon Num :{e.wagonNum} \nSeat Num:{e.seatNum}");
        }
        public static float Method1(Action<object> print, float numb)
        {
            print.Invoke(data1);
            Console.WriteLine($"number is currently: {numb}");
            return numb * 10f;
        }

        public static float Method2(Action<object> print, float numb)
        {
            print.Invoke(data2);
            Console.WriteLine($"number is currently: {numb}");
            return numb + 1f;
        }
        public static void PrintData1(object obj)
        {
            Console.WriteLine("Method 1:");
            Console.WriteLine(obj);
        }

        public static void PrintData2(object obj)
        {
            Console.WriteLine("Method 2:");
            Console.WriteLine($"Object ToString: {obj}");
        }
    }
}
