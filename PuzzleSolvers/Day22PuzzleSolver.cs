using AOC;
using AOC2017.Logic;
using AOC2017.Models;
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


        private Grid<VirusNodeState> GetInitialNetwork2()
        {
            int networkInitialSize = 25;
            var network = new Grid<VirusNodeState>(networkInitialSize, networkInitialSize);

            string[] inputLines = InputFilesHelper.GetInputFileLines("day22.txt");

            for (int i = 0; i < networkInitialSize; i++)
            {
                string currLine = inputLines[i];

                for (int j = 0; j < networkInitialSize; j++)
                {
                    if (currLine[j] == '#')
                    {
                        network.SetItem(VirusNodeState.Infected, i, j);
                    } else
                    {
                        network.SetItem(VirusNodeState.Clean, i, j);
                    }
                }
            }
            return network;
        }

        public string SolvePuzzlePart2()
        {
            Grid<VirusNodeState> initialNetwork = GetInitialNetwork2();

            var virusSimulator = new SproficaVirusSimulator(525);

            int numOfInfections = virusSimulator.RunSimulation2(initialNetwork, 10_000_000);

            return numOfInfections.ToString();
        }
    }
}
