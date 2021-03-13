using System;
using System.IO;
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
            StringTask();
            OneDimensionalArrayTask();

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
        public static void OneDimensionalArrayTask()
        {
            Console.WriteLine("Enter B:");
            int B = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter C:");
            int C = int.Parse(Console.ReadLine());
            int numOfElemes = 0;
            Console.WriteLine("Input array size");
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];
            Console.WriteLine("Enter array elements");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % B == 0 && arr[i] % C == 0)
                {
                    numOfElemes++;
                }
            }
            Console.WriteLine(numOfElemes);
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
        public static void StringTask()
        {
            List<string> strList = new List<string>();
            string str = String.Empty;

            //Записывать обработанные данные в массив строк затем в streamwriter записать этот массив в выходной файл
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while ((str = sr.ReadLine()) != null)
                {
                    if (String.IsNullOrWhiteSpace(str))
                    {
                        continue;
                    }
                    str = RemoveInnerSpaces(str.Trim());
                    strList.Add(str);
                }
            }

            using (StreamWriter sw = File.CreateText("Output.txt"))
            {
                foreach (string str1 in strList)
                {
                    sw.WriteLine(str1);
                }
            }
        }
        public static string RemoveInnerSpaces(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if(str[i] == ' ' && str[i-1] == ' ')
                {
                    continue;
                }
                sb.Append(str[i]);
            }
            Console.WriteLine(sb);
            return sb.ToString();
        }
    }
}
