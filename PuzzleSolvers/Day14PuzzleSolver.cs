using AOC;
using AOC2017.Logic;
using BirdLib;
using BirdLib.DataModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day14PuzzleSolver : IPuzzleSolver
    {
        private const string INPUT = "xlqgujun";
        //private const string INPUT = "flqrgnkx"; //Test Input

        public string SolvePuzzlePart1()
        {
            int totalSquaresUsed = 0;

            for (int i = 0; i < 128; i++)
            {
                var binaryHash = GenerateBinaryHashRowForIndex(i);
                totalSquaresUsed += binaryHash.Sum(c => c == '1' ? 1 : 0);
            }

            return totalSquaresUsed.ToString();
        }

        public string SolvePuzzlePart2()
        {
            var grid = new Grid<bool>(128,128);

            for (int i = 0; i < 128; i++)
            {
                var binaryHash = GenerateBinaryHashRowForIndex(i);

                for (int j = 0; j < 128; j++)
                {
                    grid.SetItem(binaryHash[j] == '1', i, j);

                }
            }

            var regionsCount = 0;

            for (int i = 0; i < 128; i++)
            {
                for(int j=0; j< 128; j++)
                {
                    if (grid.GetItem(i, j))
                    {
                        regionsCount++;
                        RemovePointAndNeighbours(grid, i, j);
                    }
                }
            }

            return regionsCount.ToString();
        }

        private void RemovePointAndNeighbours(Grid<bool> grid, int i, int j)
        {
           List<Point> neightbours =  GridEagle.GetAllNeighbourPointsFor(i, j, grid.ColumnSize);

            grid.SetItem(false, i, j);

            foreach (Point point in neightbours)
            {
                if (grid.GetItem(point.X, point.Y))
                {
                    RemovePointAndNeighbours(grid, point.X, point.Y);
                }
            }
        }

        private string GenerateBinaryHashRowForIndex(int index)
        {
            var hashGenerator = new KnotHashGenerator();
            var wordToHash = $"{INPUT}-{index}";
            var binaryHash = hashGenerator.GenerateHashAsBinary(wordToHash);

            return binaryHash;
        }
       
    }
}
