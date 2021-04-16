using _7th_labPart2_Delegates_and_events_.ClassesForInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7th_labPart2_Delegates_and_events_
{
    class Program
    {
        static void Main(string[] args)
        {

            Timer[] arrOfTimers = { new Timer(3, "Чтение задания"), new Timer(4, "Выполнение задания"), new Timer(5, "Проверка задания перед отправкой") };
            
            ICutDownNotifier[] arr = { new ClassWithLambdas(), new ClassWithAnonymousMethods(), new ClassWithMethods() };
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Init(arrOfTimers[i]);
                arr[i].Run(arrOfTimers[i]);
            }
            Console.ReadLine();
        }
    }
}
