using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5th_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix a = new Matrix(3, 3);
            Matrix b = new Matrix(2, 3);
            Random rnd = new Random();
            a.FillWithRandomVal(rnd);
            b.FillWithRandomVal(rnd);
            try
            {
                Matrix r = Matrix.Multiplication(a, b);
                PrintMatr(r);
            }
            catch(MatrixIncompatibleSizeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Matrix r = Matrix.Addition(a, b);
                PrintMatr(r);
            }
            catch (MatrixIncompatibleSizeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Matrix r = Matrix.Subtraction(a, b);
                PrintMatr(r);
            }
            catch (MatrixIncompatibleSizeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Matrix arr = Matrix.GetEmpty(3, 4);
            PrintMatr(arr);
            Console.WriteLine("Normal matrices");
            Matrix a_n = new Matrix(4, 4);
            Matrix b_n = new Matrix(4, 4);
            a_n.FillWithRandomVal(rnd);

            b_n.FillWithRandomVal(rnd);
            Matrix n = Matrix.Subtraction(a_n, b_n);
            PrintMatr(n);
            Console.WriteLine("===========================");
            n = Matrix.Addition(a_n, b_n);
            PrintMatr(n);
            Console.WriteLine("===========================");
            n = Matrix.Multiplication(a_n, b_n);
            PrintMatr(n);
            Console.ReadLine();
        }
        public static void PrintMatr(Matrix matr)
        {
            for (int i = 0; i < matr.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matr.matrix.GetLength(1); j++)
                {
                    Console.Write(matr.matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
