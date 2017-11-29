using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SudokuBoardValidator
{
    public class SudokuBoard
    {
        public const int GridWidth = 9;
        public const int GridHeight = 9;
        public const int SubgridWidth = 3;
        public const int SubgridHeight = 3;

        private readonly int[,] Grid;

        public SudokuBoard(int[,] grid)
        {
            Grid = grid;
        }

        public int[] GetBlockAtRow(int row)
        {
            int[] currentBlockDigits = new int[GridWidth];
            for (int column = 0; column < GridHeight; column++)
            {
                currentBlockDigits[column] = Grid[row, column];
            }

            return currentBlockDigits;
        }

        public int[] GetBlockAtColumn(int column)
        {
            int[] currentBlockDigits = new int[GridHeight];
            for (int row = 0; row < GridWidth; row++)
            {
                currentBlockDigits[row] = Grid[row, column];
            }

            return currentBlockDigits;
        }

        public int[] GetBlockAtSubgrid(int subgridRow, int subgridColumn)
        {
            int currentBlockIndex = 0;
            int[] currentBlockDigits = new int[SubgridWidth * SubgridHeight];
            for (int row = 0; row < SubgridWidth; row++)
            {
                for (int column = 0; column < SubgridHeight; column++)
                {
                    currentBlockDigits[currentBlockIndex] = Grid[row + subgridRow, column + subgridColumn];
                    currentBlockIndex += 1;
                }
            }

            return currentBlockDigits;
        }
    }
}
