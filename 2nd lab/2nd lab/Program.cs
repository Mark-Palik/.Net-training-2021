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
            string[] lines = File.ReadAllLines("inputMatr.txt").Where(x => !string.IsNullOrEmpty(x)).ToArray();
            int sizeX = lines.Length;
            int sizeY = 0;
            foreach (string line in lines)
            {
                int lengthOfRow = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).Count();
                if (sizeY < lengthOfRow)
                    sizeY = lengthOfRow;
            }
            int[,] array = new int[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                int[] row = new int[sizeY];
                lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray().CopyTo(row, 0);
                for (int j = 0; j < sizeY; j++)
                {
                    array[i, j] = row[j];
                }
            }
            // Считать строку из файла, и закинуть её в другую строку затем её сплитнуть и записать в массив 
            PrintMatrixAndFindMin(array);
            StringTask();
            OneDimensionalArrayTask();
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
            Console.WriteLine($"число элементов кратных B и C: {numOfElemes}");
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
