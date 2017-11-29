using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SudokuBoardValidator
{
    public class SudokuBoardRepo
    {
        public SudokuBoard Load(string boardFilename)
        {
            if (!Path.IsPathRooted(boardFilename))
            {
                boardFilename = Path.Combine(Environment.CurrentDirectory, boardFilename);
            }

            if (!File.Exists(boardFilename))
            {
                throw new FileNotFoundException("Sudoku board file not found!", boardFilename);
            }

            string boardText = File.ReadAllText(boardFilename);

            var boardRegEx = new Regex(@"(?<number>[1-9])");
            var matchedDigits = boardRegEx.Matches(boardText);
            if (matchedDigits.Count != SudokuBoard.GridWidth * SudokuBoard.GridHeight)
            {
                throw new InvalidDataException("Sudoku board file contains invalid data!");
            }

            var grid = new int[SudokuBoard.GridWidth, SudokuBoard.GridHeight];
            for (int row = 0; row < SudokuBoard.GridWidth; row++)
            {
                int currentMatchIndex = row * SudokuBoard.GridWidth;
                for (int column = 0; column < SudokuBoard.GridHeight; column++)
                {
                    grid[row, column] = int.Parse(matchedDigits[currentMatchIndex].Value);
                    currentMatchIndex += 1;
                }
            }

            return new SudokuBoard(grid);
        }
    }
}
