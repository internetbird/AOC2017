using AOC;
using BirdLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day16PuzzleSolver : IPuzzleSolver
    {

        public string SolvePuzzlePart1()
        {
            string programsPositions = "abcdefghijklmnop";
            
            string inputText = InputFilesHelper.GetInputFileText("day16.txt");

            string[] moves = inputText.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (string move in moves)
            {
                programsPositions = ExecuteMove(programsPositions, move);

            }

            return programsPositions;
        }

        private string ExecuteMove(string programsPositions, string move)
        {
            if (move[0] == 'x') //Exchange
            {
                int[] positions = move.Substring(1).Split('/').Select(int.Parse).ToArray();
                programsPositions =  programsPositions.SwapIndexes(positions[0], positions[1]);
            }
            else if (move[0] == 's') //Spin
            {
                int spinCount = int.Parse(move.Substring(1));
                programsPositions = programsPositions.ShiftRight(spinCount);
            }
            else if (move[0] == 'p') //Partner
            {
                string[] programs = move.Substring(1).Split('/');
                int index1 = programsPositions.IndexOf(programs[0]);
                int index2 = programsPositions.IndexOf(programs[1]);

                programsPositions = programsPositions.SwapIndexes(index1, index2);

            }

            return programsPositions;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
