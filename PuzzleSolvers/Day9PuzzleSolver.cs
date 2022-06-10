using AOC;
using AOC2017.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day9PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var inputText = InputFilesHelper.GetInputFileText("day9.txt");

            var calculator = new StreamScoreCalculator();

            int score = calculator.CalculateStreamScore(inputText);

            return score.ToString();
        }

        public string SolvePuzzlePart2()
        {
            var inputText = InputFilesHelper.GetInputFileText("day9.txt");

            var calculator = new StreamScoreCalculator();

            int score = calculator.CountGarbageChars(inputText);

            return score.ToString();
        }
    }
}
