using AOC;
using AOC2017.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day10PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string inputText = InputFilesHelper.GetInputFileText("day10.txt");

            List<int> inputLengths = inputText.Split(',').Select(int.Parse).ToList();

            var hashGenerator = new KnotHashGenerator();

            List<int> hash = hashGenerator.GenerateHash(inputLengths);

            return (hash[0]*hash[1]).ToString();

        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
