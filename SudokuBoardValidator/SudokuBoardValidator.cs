using System;

namespace SudokuBoardValidator
{
    public class SudokuBoardValidator
    {
        private SudokuBoard sudokuBoard;

        public void Validate(SudokuBoard sudokuBoard)
        {
            this.sudokuBoard = sudokuBoard;

            ValidateGridRows();
            ValidateGridColumns();
            ValidateSubgrids();
        }

        private void ValidateGridRows()
        {
            for (int row = 0; row < SudokuBoard.GridWidth; row++)
            {
                int[] currentBlockDigits = sudokuBoard.GetBlockAtRow(row);

                try
                {
                    ValidateBlock(currentBlockDigits);
                }
                catch
                {
                    Console.WriteLine($"Invalid row at {row + 1}.");
                    throw;
                }
            }
        }

        private void ValidateGridColumns()
        {
            for (int column = 0; column < SudokuBoard.GridHeight; column++)
            {
                int[] currentBlockDigits = sudokuBoard.GetBlockAtColumn(column);

                try
                {
                    ValidateBlock(currentBlockDigits);
                }
                catch
                {
                    Console.WriteLine($"Invalid column at {column + 1}.");
                    throw;
                }
            }
        }

        private void ValidateSubgrids()
        {
            for (int subgridRow = 0; subgridRow < SudokuBoard.GridWidth; subgridRow += SudokuBoard.SubgridWidth)
            {
                for (int subgridColumn = 0; subgridColumn < SudokuBoard.GridHeight; subgridColumn += SudokuBoard.SubgridHeight)
                {
                    int[] currentBlockDigits = sudokuBoard.GetBlockAtSubgrid(subgridRow, subgridColumn);

                    try
                    {
                        ValidateBlock(currentBlockDigits);
                    }
                    catch
                    {
                        Console.WriteLine($"Invalid subgrid at {subgridRow + 1},{subgridColumn + 1}.");
                        throw;
                    }
                }
            }
        }

        private void ValidateBlock(int[] block)
        {
            if (block == null || block.Length == 0)
            {
                throw new ArgumentNullException(nameof(block));
            }

            Array.Sort(block);
            for (int i = 0; i < block.Length; i++)
            {
                if (block[i] != i + 1)
                {
                    throw new ArgumentException("Invalid block");
                }
            }
        }
    }
}
