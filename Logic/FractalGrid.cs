using AOC2017.Parsers;
using BirdLib.DataModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
            int iterationCount = 0;
            Console.WriteLine("** INITIAL STATE **");
            Console.WriteLine(_grid);

            while (iterationCount < numOfIterations)
            {
                _grid = CalculateNextIterationGrid();
                iterationCount++;

                Console.WriteLine($"** ITERATION {iterationCount} **");
                Console.WriteLine(_grid);
            }

        }

        private Grid<bool> CalculateNextIterationGrid()
        {
            int nextGridSize = _grid.RowSize % 2 == 0 ? _grid.RowSize + (_grid.RowSize / 2) :
                 _grid.RowSize + (_grid.RowSize / 3);

            var nextGrid = new Grid<bool>(nextGridSize, nextGridSize);

            List<Grid<bool>> gridSquares = GetGridSquares();

            List<Grid<bool>> nextInterationSquares = GetNextIterationSquares(gridSquares);

            MergeSquares(nextGrid, nextInterationSquares);

            return nextGrid;
        }

        private void MergeSquares(Grid<bool> gridToMergeTo,  List<Grid<bool>> squaresToMerge)
        {
            int squareSize = squaresToMerge[0].RowSize;
            int gridSize = gridToMergeTo.RowSize;
            var squaresEnumerator = squaresToMerge.GetEnumerator();

            for (int i = 0; i < gridSize; i+= squareSize)
            {
                for (int j = 0; j < gridSize; j+= squareSize)
                {
                    squaresEnumerator.MoveNext();
                    gridToMergeTo.SetSubGrid(i, j, squaresEnumerator.Current);
                }
            }
        }

        private List<Grid<bool>> GetNextIterationSquares(List<Grid<bool>> gridSquares)
        {
            var nextGenerationSquares = new List<Grid<bool>>();

            foreach (Grid<bool> square in gridSquares)
            {
                Grid<bool> matchingRuleSquare = GetMatchingRuleSquare(square);
                nextGenerationSquares.Add(matchingRuleSquare);
            }

            return nextGenerationSquares;
        }

        private Grid<bool> GetMatchingRuleSquare(Grid<bool> square)
        {
            foreach (FractalGridRule rule in _rules)
            {
                if (IsRuleMatch(rule, square))
                {
                    return rule.DestinationGrid;
                }
            }
            throw new Exception("No matching rule found!");
        }

        private bool IsRuleMatch(FractalGridRule rule, Grid<bool> square)
        {
           return rule.SourceGrids.Any(grid => grid.Equals(square));
        }

        private List<Grid<bool>> GetGridSquares()
        {
            int squareSize = _grid.RowSize % 2 == 0 ? 2 : 3;

            var gridSquares = new List<Grid<bool>>();

            for (int i = 0; i < _grid.RowSize; i += squareSize)
            {
                for (int j = 0; j < _grid.RowSize; j += squareSize)
                {
                    Grid<bool> square = _grid.GetSubGridSquare(i, j, squareSize);
                    gridSquares.Add(square);
                }
            }

            return gridSquares;
        }

        public int GetNumOfOnPixels() => _grid.GetValueCount(true);

        private List<FractalGridRule> ParseRules(string[] ruleLines)
        {
            var rules = new List<FractalGridRule>();

            foreach (string ruleLine in ruleLines)
            {
                var rule = new FractalGridRule();
                string[] ruleParts = ruleLine.Split("=>");

                rule.SourceGrids = GetAllPossibleSourceGrids(ParseGrid(ruleParts[0].Trim()));
                rule.DestinationGrid = ParseGrid(ruleParts[1].Trim());

                rules.Add(rule);
            }

            return rules;
        }

        private Grid<bool> ParseGrid(string dataString) => FractalGridParser.ParseGrid(dataString);

        private List<Grid<bool>> GetAllPossibleSourceGrids(Grid<bool> grid)
        {
            var possibleSourceGrids = new List<Grid<bool>> { grid};

            Grid<bool> flippedVertically = grid.FlipVertically();
            Grid<bool> flippedVerticallyRight = flippedVertically.RotateRight();
            Grid<bool> flippedVerticallyLeft = flippedVertically.RotateLeft();
            Grid<bool> flippedHorizontally = grid.FlipHorizontally();
            Grid<bool> flippedHorizontallyRight = flippedHorizontally.RotateRight();
            Grid<bool> flippedHorizontallyLeft = flippedHorizontally.RotateLeft();

            Grid<bool> rotatedRight = grid.RotateRight();
            Grid<bool> rotatedRight2 = rotatedRight.RotateRight();
            Grid<bool> rotatedLeft = grid.RotateLeft();
            Grid<bool> rotatedLeft2 = rotatedLeft.RotateLeft();

            possibleSourceGrids.AddRange(new List<Grid<bool>>{ 
                flippedVertically,
                flippedHorizontally,
                rotatedLeft,
                rotatedLeft2,
                rotatedRight,
                rotatedRight2,
                flippedHorizontallyRight,
                flippedHorizontallyLeft,
                flippedVerticallyRight,
                flippedVerticallyLeft });

            return possibleSourceGrids;
        }
    }
}
