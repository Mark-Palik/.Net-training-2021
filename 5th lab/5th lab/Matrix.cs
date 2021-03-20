using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _5th_lab
{
    public class Matrix
    {
        public int[,] matrix;
        public Matrix(int rowNums, int colNums)
        {
            matrix = new int[rowNums, colNums];
        }
        public static Matrix Addition(Matrix a, Matrix b)
        {
            if (a.matrix.GetLength(0) != b.matrix.GetLength(0) || a.matrix.GetLength(1) != b.matrix.GetLength(1))
            {
                throw new MatrixIncompatibleSizeException(a, b, $"You can only add matrices with the same sizes\nFirst matr size: {a.matrix.GetLength(0)} * {a.matrix.GetLength(1)}\n Second matr size: {b.matrix.GetLength(0)} * {b.matrix.GetLength(1)}");
            }
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
            if (a.matrix.GetLength(0) != b.matrix.GetLength(0) || a.matrix.GetLength(1) != b.matrix.GetLength(1))
            {
                throw new MatrixIncompatibleSizeException(a, b, $"You can only subtract matrices with the same sizes\nFirst matr size: {a.matrix.GetLength(0)} * {a.matrix.GetLength(1)}\n Second matr size: {b.matrix.GetLength(0)} * {b.matrix.GetLength(1)}");
            }
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
        public static Matrix Multiplication(Matrix a, Matrix b)
        {
            int rA = a.matrix.GetLength(0);
            int cA = a.matrix.GetLength(1);
            int rB = b.matrix.GetLength(0);
            int cB = b.matrix.GetLength(1);
            if (cA != rB)
            {
                throw new MatrixIncompatibleSizeException(a, b, $"Incompatible matrix sizes number of columns of the 1st matrix should be equal to the number of rows of the second\n First matr size: {a.matrix.GetLength(0)} * {a.matrix.GetLength(1)}\n Second matr size: {b.matrix.GetLength(0)} * {b.matrix.GetLength(1)}");
            }

            Matrix r = new Matrix(a.matrix.GetLength(0), b.matrix.GetLength(1));
            for (int i = 0; i < a.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < b.matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < b.matrix.GetLength(0); k++)
                    {
                        r.matrix[i, j] += a.matrix[i, k] * b.matrix[k, j];
                    }
                }
            }
            return r;
        }
        public static Matrix GetEmpty(int rows, int cols)
        {
            return new Matrix(rows, cols);
        }
        
        public void FillWithRandomVal(Random rand)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(0, 10);
                }
            }
        }
    }
}
