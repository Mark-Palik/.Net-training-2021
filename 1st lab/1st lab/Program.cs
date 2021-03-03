using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1st_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            RootOfNthPower();
            KmvLoops_1();
            KmvLoops_2();
            KmvLoops_3();
            A_Cycle();
            E_Cycle();
            DecimalToBinary();
            Console.ReadLine();
        }
        public static void RootOfNthPower()
        {
            Console.WriteLine("================Root of number Newton's method task================");
            Console.WriteLine("Введите число от которого считаем корень :");
            double num = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите степень корня :");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите точность :");
            double eps = double.Parse(Console.ReadLine());
            double res = num;
            double prev = 0;
            while (Math.Abs(prev - res) >= eps)
            {
                prev = res;
                res = (1.0 / n) * ((n - 1) * res + num / (Math.Pow(res, n - 1)));
            }
            Console.WriteLine($"Root of number {num} is {res}");
            Console.WriteLine($"Root of number {num} using Math.Pow: {Math.Pow(num, 1d / n)}");
        }
        public static void A_Cycle()
        {
            Console.WriteLine("================A_Loops================");
            Console.WriteLine("Введите k:");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите x:");
            double x = double.Parse(Console.ReadLine());
            int n = 0;
            double summ = 0;
            while (n <= k)
            {
                summ += 1/(2*(double)n+1) * Math.Pow((x - 1) / (x + 1), 2*n + 1);
                n++;
            }
            Console.WriteLine($"Сумма ряда {summ}");
        }
        public static void DecimalToBinary()
        {
            Console.WriteLine("================Decimal to binary task================");
            Console.Write("Decimal: ");
            int decimalNumber = int.Parse(Console.ReadLine());
            Console.WriteLine($"Число в двоичной системе встроенной функцией : {Convert.ToString(decimalNumber, 2)}");
            int remainder;
            string result = string.Empty;
            while (decimalNumber > 0)
            {
                remainder = decimalNumber % 2;
                decimalNumber /= 2;
                result = remainder.ToString() + result;
            }
            Console.WriteLine("Binary:  {0}", result);
        }
        public static double Equation(double x)
        {
            return x - (1d / (3 + Math.Sin(3.6 * x)));
        }
        public static void E_Cycle()
        {
            Console.WriteLine("================E_Loops================");
            Console.WriteLine("Введите а :");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите b :");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите точность :");
            double precision = double.Parse(Console.ReadLine());
            double c;
            do
            {
                c = (a + b) / 2;
                if (Equation(b) * Equation(c) < 0)
                {
                    a = c;
                }
                else
                {
                    b = c;
                }
            } while (Math.Abs(Equation(c)) >= precision);
            Console.WriteLine($"Root of equation {c}");
        }
        public static void KmvLoops_1()
        {
            Console.WriteLine("================KMV_Loops1================");
            Console.WriteLine("Введите x:");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите точность:");
            double precision = double.Parse(Console.ReadLine());
            if (precision >= 1)
            {
                Console.WriteLine("Сумма равна 0 т.к первое слагаемое меньше точности");
                return;
            }
            double summ = 1;
            double check_xn = 1;
            double check_xn1;
            double true_xn = 1;
            double true_xn1;
            for (long n = 0; Math.Abs(check_xn1 = check_xn * x / (n + 1)) >= precision && !double.IsInfinity(check_xn1); n++)
            {
                true_xn1 = true_xn * (Math.Cos((n + 1) * Math.PI / 4d) * x) / ((n + 1) * Math.Cos((n) * Math.PI / 4d));
                summ += true_xn1;
                check_xn = check_xn1;
                true_xn = true_xn1;
            }
            Console.WriteLine($"Сумма ряда: {summ}");
        }
        public static void KmvLoops_2()
        {
            Console.WriteLine("================KMV_Loops2================");
            Console.WriteLine("Введите точность: ");
            double precision = double.Parse(Console.ReadLine());
            double next = 1d / (1 * (1 + 1) * (1 + 2));
            double summ = 0;
            for(int n = 2; next >= precision; n++)
            {
                summ += next;
                next = 1d / (n * (n + 1) * (n + 2));
            }
            Console.WriteLine($"Сумма ряда : {summ}");
        }
        public static void KmvLoops_3()
        {
            // По причине того что ряд расходится я в while изменил условие
            Console.WriteLine("================KMV_Loops3================");
            Console.WriteLine("Введите x :");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите точность :");
            double precision = double.Parse(Console.ReadLine());
            double an_prev;
            double an = x;
            Console.WriteLine(an);
            do
            {
                an_prev = an;
                an = 2 * an_prev + (x / (4 + Math.Pow(an_prev, 2)));
                Console.WriteLine($"{Math.Abs(an_prev - an)}");
            }
            while (Math.Abs(an_prev - an) <= precision);
            Console.WriteLine($"Первый член который отличается не более чем на {precision} : {an}");
        }

        
        public static void TestProg()
        {
            Console.WriteLine("Enter data");
            string inputData = Console.ReadLine();
            string[] parsedData = inputData.Split(',');
            string result = String.Empty;
            for (int i = 0; i < parsedData.Length; i+=2)
            {
                string X = parsedData[i];
                string Y = parsedData[i + 1];
                result += $"X: {X} Y: {Y} ";
            }
            Console.WriteLine(result);
        }
        public static void TestProg(string fileName)
        {
            Console.WriteLine("Enter data");
            StreamReader sr = new StreamReader(fileName);
            string inputData = sr.ReadToEnd();
            string[] parsedData = inputData.Split(',');
            string result = String.Empty;
            for (int i = 0; i < parsedData.Length; i += 2)
            {
                string X = parsedData[i];
                string Y = parsedData[i + 1];
                result += $"X: {X} Y: {Y} ";
            }
            Console.WriteLine(result);
        }
    }
}
