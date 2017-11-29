using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuBoardGenerator
{
    public class SudokuBoardGenerator
    {
        public SudokuBoard Generate()
        {
            var grid = new int[SudokuBoard.GridWidth, SudokuBoard.GridHeight];
            var sudokuBoard = new SudokuBoard(grid);
            var random = new Random();

            for (int row = 0; row < SudokuBoard.GridWidth; row++)
            {
                int memory = 0;
                int column = 0;
                while (column < SudokuBoard.GridHeight)
                {
                    var availableNumbers = Enumerable.Range(1, 9).ToList();
                    var blockAtRow = sudokuBoard.GetBlockAtRow(row);
                    var blockAtColumn = sudokuBoard.GetBlockAtColumn(column);
                    var blockAtSubgrid = sudokuBoard.GetBlockAtSubgrid(row / SudokuBoard.SubgridWidth, column / SudokuBoard.SubgridHeight);
                    availableNumbers.RemoveAll(n => blockAtRow.Contains(n) || blockAtColumn.Contains(n) || blockAtSubgrid.Contains(n) || n == memory);

                    if (availableNumbers.Count == 0)
                    {
                        if (column > 0)
                        {
                            column -= 1;
                        }
                        else
                        {
                            column = SudokuBoard.GridWidth;
                            row -= 1;
                        }

                        memory = grid[row, column];
                        grid[row, column] = 0;
                        continue;
                    }

                    int candidateNumberIndex = random.Next(availableNumbers.Count);
                    int candidateNumber = availableNumbers[candidateNumberIndex];
                    availableNumbers.Remove(candidateNumber);

                    grid[row, column] = candidateNumber;
                    memory = 0;
                    column += 1;
                }
            }

            return sudokuBoard;
        }
    }
}
