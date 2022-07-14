using AOC;
using AOC2017.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day14PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            int totalSquaresUsed = 0;
            string input = "xlqgujun";

            var hashGenerator = new KnotHashGenerator();

            for (int i = 0; i < 128; i++)
            {
                var wordToHash = $"{input}-{i}";

                var binaryHash = hashGenerator.GenerateHashAsBinary(wordToHash);

                totalSquaresUsed += binaryHash.Sum(c => c == '1' ? 1 : 0);
            }

            return totalSquaresUsed.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
