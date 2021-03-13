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
            Console.WriteLine("Addition of two vectors " + Vector.Addition(a, b));
            Console.WriteLine("Multiplying vector by number " + Vector.MultiplyByNumber(a, 5));
            Console.WriteLine("Subtraction of two vectors " + Vector.Subtraction(a, b));
            Console.WriteLine("Vector multiplication " + Vector.VectorMultiplication(a, b));
            Console.WriteLine("Scalar vector multiplication " + Vector.ScalarMultiplication(a, b));
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
