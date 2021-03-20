using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6th_lab
{
    class ProgramHelper : ProgramConverter ,ICodeChecker
    {
        public bool CheckCodeSyntax(string str, string language)
        {
            switch (language)
            {
                case "C#":
                    return true;
                case "VB":
                    return false;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
