using AOC;
using AOC2017.Logic;
using BirdLib.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day22PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            Grid<bool> initialNetwork = GetInitialNetwork();

            var virusSimulator = new SproficaVirusSimulator();

            int numOfInfections = virusSimulator.RunSimulation(initialNetwork, 10000);

            return numOfInfections.ToString();
        }

        private Grid<bool> GetInitialNetwork()
        {
            int networkInitialSize = 25;
            var network = new Grid<bool>(networkInitialSize, networkInitialSize);

            string[] inputLines = InputFilesHelper.GetInputFileLines("day22.txt");

            for (int i = 0; i < networkInitialSize; i++)
            {

                string currLine = inputLines[i];

                for (int j = 0; j < networkInitialSize; j++)
                {
                    bool infected = currLine[j] == '#';
                    network.SetItem(infected, i, j);
                }
            }
            return network;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
