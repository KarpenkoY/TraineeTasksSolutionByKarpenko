using System;
using System.Linq;

namespace Sudoku
{
    static class Sudoku
    {
        public static bool ValidateSudoku(int[,] sudoku)
        {
            // Implicit declaration and initialization of N (sudoku size) and root N (square size)
            if (GetAndValidateSizes(sudoku, out int N, out int sqrtN)) return false;

            int[] row   = new int[N];
            int[] col   = new int[N];
            int[] sqrt  = new int[N];

            // In each iteration of the loop, one row, a column and a square are initialized
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    // Row and Column initialization
                    row[j] = sudoku[i, j];
                    col[j] = sudoku[j, i];

                    // Square is initialized only from 0.0 index of it in Sudoku
                    if (i % sqrtN == 0 && j % sqrtN == 0)
                    {
                        for (int k = 0; k < N; k++)
                        {
                            int sqrtRow = k % sqrtN + i;
                            int sqrtCol = k / sqrtN + j;

                            // Small square initialization
                            sqrt[k]     = sudoku[sqrtRow, sqrtCol];
                        }
                    }
                }

                if (IsRowColSquareHaveDublicates(i + 1, row, col, sqrt)) return false;
            }

            // No duplicates in rows, columns and squares, sudoku solution is correct
            return true;
        }

        private static bool GetAndValidateSizes(int[,] sudoku, out int N, out int sqrtN)
        {
            double doubleN      = (int)Math.Sqrt(sudoku.Length);
            double doubleSqrtN  = (int)Math.Sqrt(doubleN);

            N                   = (int)doubleN;
            sqrtN               = (int)doubleSqrtN;

            // Does N and square — integer?; N more than 1?
            // If not, then sudokku size is not correct
            if (doubleN % 1 != 0 || doubleSqrtN % 1 != 0)   return true;
            if (doubleN < 2)                                return true;

            // If yes, size is corret
            return false;
        }

        private static bool IsRowColSquareHaveDublicates(int num, int[] row, int[] col, int[] sqrt)
        {
            // Does each row, column, and small square contain each of the numbers from 0 to N?
            // If not, then there is a duplicate, and sudoku solution is not correct
            if (!(row.Contains(num) || col.Contains(num)))  return true;
            if (!(sqrt.Contains(num)))                      return true;

            // If yes, solution is corret
            return false;
        }
    }
}
