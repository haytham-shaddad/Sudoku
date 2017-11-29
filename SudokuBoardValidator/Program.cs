using System;

namespace SudokuBoardValidator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: SudokuBoardValidator filename");
                return;
            }

            string boardFilename = args[0];

            try
            {
                var sudokuBoardRepo = new SudokuBoardRepo();
                var sudokuBoard = sudokuBoardRepo.Load(boardFilename);
                var sudokuBoardValidator = new SudokuBoardValidator();
                sudokuBoardValidator.Validate(sudokuBoard);

                Console.WriteLine("Valid Sudoku board.");
            }
            catch
            {
                Console.WriteLine("Invalid Sudoku board!");
            }
        }
    }
}
