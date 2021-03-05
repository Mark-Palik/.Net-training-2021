﻿using System;
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
            StringTask(@"F:\TestString\");
            string str = RemoveInnerSpaces("azzz   aazzz   aaaaa");
            Console.WriteLine(str);

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
        public static void StringTask(string path)
        {
            string inputPath = path + "input.txt";
            string outputPath = path + "Output.txt";
            List<string> strList = new List<string>();
            string str = String.Empty;

            //Записывать обработанные данные в массив строк затем в streamwriter записать этот массив в выходной файл
            using (StreamReader sr = new StreamReader(inputPath))
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

            using (StreamWriter sw = File.CreateText(outputPath))
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