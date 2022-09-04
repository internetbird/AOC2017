using AOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day17PuzzleSolver : IPuzzleSolver
    {
        private const int PuzzleInput = 371;

        public string SolvePuzzlePart1()
        {
            var numsList = new List<int> { 0, 1 };
            int currIndex = 1;
            for (int i = 2; i < 2018; i++)
            {
                int nextIndex = GetNextIndex(currIndex, i);
                numsList.Insert(nextIndex, i);
                currIndex = nextIndex;
            }
            int index2017 =  numsList.IndexOf(2017);
            return numsList[index2017 + 1].ToString();
        }

        private int GetNextIndex(int currIndex, int length)
        {
            int skipSize = PuzzleInput % length;

            int nextIndex = (currIndex + skipSize + 1) % length;
            return nextIndex;
        }

        public string SolvePuzzlePart2()
        {
          
            int currIndex = 1;
            int indexOfZero = 0;
            int numAfterZero = 1;
            for (int i = 2; i < 50000000; i++)
            {
                int nextIndex = GetNextIndex(currIndex, i);
                if (nextIndex == indexOfZero + 1)
                {
                    numAfterZero = i;
                }

                if(nextIndex <= indexOfZero)
                {
                    indexOfZero++;
                }
              
                currIndex = nextIndex;
            }
            return numAfterZero.ToString();
        }
    }
}
