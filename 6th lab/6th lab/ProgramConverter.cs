using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6th_lab
{
    class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string input)
        {
            return "Converted to C#";
        }

        public string ConvertToVB(string input)
        {
            return "Converted to VB";
        }
    }
}
