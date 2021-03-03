using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2nd_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[3, 3];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }
            PrintMatrixAndFindMin(array);
            Console.ReadLine();
        }
        public static void PrintMatrixAndFindMin(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
            int min = int.MaxValue;
            int indexOfColumn = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                        indexOfColumn = j;
                    }
                }
            }
            Console.WriteLine($"min elem {min}, index of column: {indexOfColumn}");
        }
    }
}
