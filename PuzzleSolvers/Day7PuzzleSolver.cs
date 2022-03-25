using AOC;
using AOC2017.Logic;
using AOC2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day7PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day7.txt");

            var programNodes = new List<ProgramTreeNode>();
            var parser = new ProgramTreeNodeParser();

            foreach (string line in inputLines)
            {
                programNodes.Add(parser.ParseLine(line));
            }

            List<ProgramTreeNode> parentPrograms = programNodes
                .Where(node => node.SubProgramsNames != null).ToList();

            var allSubPrograms = new List<string>();

            parentPrograms.ForEach(program => allSubPrograms.AddRange(program.SubProgramsNames));

            ProgramTreeNode rootNode = parentPrograms.Find(program => !allSubPrograms.Contains(program.Name));

            return rootNode.Name;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
