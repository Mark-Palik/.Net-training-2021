using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4th_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector a = InputMethod();
            Vector b = InputMethod();
            Vector c = a + b;
            Console.WriteLine("Addition of two vectors " + c);
            c = a * 5;
            Console.WriteLine("Multiplying vector by number " + c);
            c = a - b;
            Console.WriteLine("Subtraction of two vectors " + c);
            double d = a * b;
            Console.WriteLine("Scalar vector multiplication " + d);
            Console.ReadLine();
        }
        public static Vector InputMethod()
        {
            Console.WriteLine("Enter coordinates for vector");
            double X = double.Parse(Console.ReadLine());
            double Y = double.Parse(Console.ReadLine());
            double Z = double.Parse(Console.ReadLine());
            return new Vector(X, Y, Z);
        }
    }
}
