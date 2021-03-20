using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6th_lab
{
    interface ICodeChecker
    {
        bool CheckCodeSyntax(string str, string language);
    }
}
