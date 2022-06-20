using AOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day11PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var inputText = InputFilesHelper.GetInputFileText("day11.txt");

            string[] directions = inputText.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();

            int x = 0;
            int y = 0;
            int z = 0;

            for (int i = 0; i < directions.Length; i++)
            {
                var direction = directions[i].Trim();

                switch (direction)
                {
                    case "n":
                        y++;
                        z--;
                        break;
                    case "s":
                        y--;
                        z++;
                        break;
                    case "ne":
                        x++;
                        z--;
                        break;
                    case "nw":
                        x--;
                        y++;
                        break;
                    case "se":
                        x++;
                        y--;   
                        break;
                    case "sw":
                        x--;
                        z++;
                        break;

                }
            }


            return ((Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2).ToString();
        }

        public string SolvePuzzlePart2()
        {
            var inputText = InputFilesHelper.GetInputFileText("day11.txt");

            string[] directions = inputText.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();

            int x = 0;
            int y = 0;
            int z = 0;

            var distances = new List<int>();


            for (int i = 0; i < directions.Length; i++)
            {
                var direction = directions[i].Trim();

                switch (direction)
                {
                    case "n":
                        y++;
                        z--;
                        break;
                    case "s":
                        y--;
                        z++;
                        break;
                    case "ne":
                        x++;
                        z--;
                        break;
                    case "nw":
                        x--;
                        y++;
                        break;
                    case "se":
                        x++;
                        y--;
                        break;
                    case "sw":
                        x--;
                        z++;
                        break;

                }

                distances.Add((Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2);
            }


            return distances.Max().ToString();
        }
    }
}
