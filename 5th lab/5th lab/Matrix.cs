using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5th_lab
{
    class Matrix
    {
        public int[,] matrix;
        public Matrix(int rowNums, int colNums)
        {
            matrix = new int[rowNums, colNums];
        }
        public static Matrix Addition(Matrix a, Matrix b)
        {
            Matrix matr = new Matrix(a.matrix.GetLength(0), a.matrix.GetLength(0));
            for (int i = 0; i < matr.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matr.matrix.GetLength(1); j++)
                {
                    matr.matrix[i, j] = a.matrix[i,j] + b.matrix[i,j];
                }
            }
            return matr;
        }
        public static Matrix Subtraction(Matrix a, Matrix b)
        {
            Matrix matr = new Matrix(a.matrix.GetLength(0), a.matrix.GetLength(0));
            for (int i = 0; i < matr.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matr.matrix.GetLength(1); j++)
                {
                    matr.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                }
            }
            return matr;
        }
    }
}
