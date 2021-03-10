using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle(3.5);
            Console.WriteLine($"Square of c1 : {c1.Square()} and perimeter is {c1.Perimeter()}");
            try
            {
                Circle c2 = new Circle(0);
                Circle c3 = new Circle(-5);
            }
            catch (ArgumentException)
            {

                Console.WriteLine("You can't instantiate circles with radius less or equal to 0");
            }
            Console.ReadLine();
        }
    }
}
