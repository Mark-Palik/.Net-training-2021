using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5th_lab
{
    public class MatrixIncompatibleSizeException : ApplicationException
    {
        public int rowFirstMatr;
        public int colFirstMatr;
        public int rowSecondMatr;
        public int colSecondMatr;
        public MatrixIncompatibleSizeException(Matrix a, Matrix b, string message) : base(message)
        {
            rowFirstMatr = a.matrix.GetLength(0);
            colFirstMatr = a.matrix.GetLength(1);
            rowSecondMatr = b.matrix.GetLength(0);
            colSecondMatr = b.matrix.GetLength(1);
        }
        public MatrixIncompatibleSizeException(Matrix a, Matrix b)
        {
            rowFirstMatr = a.matrix.GetLength(0);
            colFirstMatr = a.matrix.GetLength(1);
            rowSecondMatr = b.matrix.GetLength(0);
            colSecondMatr = b.matrix.GetLength(1);
        }
    }
}
