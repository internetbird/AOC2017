using AOC;
using AOC2017.PuzzleSolvers;
using BirdLib.AOC;
using System;
using System.Threading.Tasks;

namespace AOC2017
{
    class Program
    {
        static void Main(string[] args)
        {
            IPuzzleSolver solver = new Day10PuzzleSolver();

            var solution =  solver.SolvePuzzlePart2();
            Console.WriteLine($"The solution to the puzzle is: {solution}");

            Console.ReadKey();
        }
    }
}
