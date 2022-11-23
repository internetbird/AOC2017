using BirdLib.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Parsers
{
    public static class FractalGridParser
    {
        public static Grid<bool> ParseGrid(string dataString)
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
    }
}
