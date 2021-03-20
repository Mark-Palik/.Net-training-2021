using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6th_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Random str.";
            string language = "VB";
            ProgramConverter[] array = { new ProgramConverter(), new ProgramConverter(), new ProgramHelper(), new ProgramHelper() };
            foreach (var item in array)
            {
                if (item is ICodeChecker)
                {
                    ICodeChecker check = item as ICodeChecker;
                    if (check.CheckCodeSyntax(input, language))
                    {
                        Console.WriteLine(item.ConvertToVB(input));
                    }
                    else
                    {
                        Console.WriteLine(item.ConvertToCSharp(input));
                    }
                }
                else
                {
                    Console.WriteLine(item.ConvertToCSharp(input));
                    Console.WriteLine(item.ConvertToVB(input));
                }
            }
            Console.ReadLine();
        }
    }
}
