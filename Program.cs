using AOC;
using AOC2017.PuzzleSolvers;
using BirdLib.AOC;
using System;
using System.Threading.Tasks;

namespace AOC2017
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IAsyncPuzzleSolver solver = new Day8PuzzleSolver();

            var solution =  await solver.SolvePuzzlePart1();
            Console.WriteLine($"The solution to the puzzle is: {solution}");

            Console.ReadKey();
        }
    }
}
