using BirdLib.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class FractalGrid
    {
        private Grid<bool> _grid;
        private List<FractalGridRule> _rules;

        private const string InitalState = ".#./..#/###";

        public FractalGrid(string[] ruleLines)
        {
            _grid = ParseGrid(InitalState);
            _rules = ParseRules(ruleLines);

        }



        public void RunInterations(int numOfIterations)
        {

        }

        public int GetNumOfOnPixels() => _grid.GetValueCount(true);

        private Grid<bool> ParseGrid(string dataString)
        {
            string[] lines = dataString.Split('/');

            int gridSize = lines[0].Length;
            var grid = new Grid<bool>(gridSize, gridSize);

            for (int i = 0; i < gridSize; i++)
            {
                string currLine = lines[i];
                for (int j = 0; j < gridSize; j++)
                {
                    bool value = currLine[j] == '#' ? true : false;
                    grid.SetItem(value, i, j);
                }
            }

            return grid;
        }

        private List<FractalGridRule> ParseRules(string[] ruleLines)
        {
            var rules = new List<FractalGridRule>();

            foreach (string ruleLine in ruleLines)
            {
                var rule = new FractalGridRule();
                string[] ruleParts = ruleLine.Split("=>");

                rule.SourceGrid = ParseGrid(ruleParts[0].Trim());
                rule.DestinationGrid = ParseGrid(ruleParts[1].Trim());

                rules.Add(rule);
            }


            return rules;

        }
    }
}
