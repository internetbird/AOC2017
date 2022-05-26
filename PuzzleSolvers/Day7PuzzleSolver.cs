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
            List<ProgramTreeNode> programNodes = GetInputProgramNodes();

            List<ProgramTreeNode> parentPrograms = programNodes
                .Where(node => node.SubProgramsNames != null).ToList();

            var allSubPrograms = new List<string>();

            parentPrograms.ForEach(program => allSubPrograms.AddRange(program.SubProgramsNames));

            ProgramTreeNode rootNode = parentPrograms.Find(program => !allSubPrograms.Contains(program.Name));

            return rootNode.Name;
        }

        private static List<ProgramTreeNode> GetInputProgramNodes()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day7.txt");

            var programNodes = new List<ProgramTreeNode>();
            var parser = new ProgramTreeNodeParser();

            foreach (string line in inputLines)
            {
                programNodes.Add(parser.ParseLine(line));
            }

            return programNodes;
        }

        public string SolvePuzzlePart2()
        {
            List<ProgramTreeNode> programNodes = GetInputProgramNodes();

            var weightCalculator = new ProgramTreeNodeWeightCalculator();

            weightCalculator.CalculateNodesWeight(programNodes);

            //The root node is : svugo
            var parentNode = programNodes.Find(node => node.Name == "svugo");

            var currentNode = parentNode;
            var imbalancedNode = parentNode;

            while (currentNode != null)
            {
                var weightsDictonary = new Dictionary<int, List<string>>();

                Console.WriteLine($"NODE {currentNode.Name}");

                foreach (string childNodeName in currentNode.SubProgramsNames)
                {
                    int nodeWeight = weightCalculator.GetWeightForNode(childNodeName);

                    Console.WriteLine($"-----  {childNodeName} -> {nodeWeight}");

                    if (weightsDictonary.ContainsKey(nodeWeight))
                    {
                        weightsDictonary[nodeWeight].Add(childNodeName);

                    } else
                    {
                        weightsDictonary.Add(nodeWeight, new List<string> { childNodeName});
                    }
                }

                if (weightsDictonary.Keys.Count > 1)
                {
                    var imbalancedKvp = weightsDictonary.Where(kvp => kvp.Value.Count == 1).First();
                    imbalancedNode = programNodes.Find(node => node.Name == imbalancedKvp.Value[0]);
                    currentNode = imbalancedNode;
                } else
                {
                    currentNode = null; 
                }

                Console.WriteLine("----------------------------------------");
            }

            Console.WriteLine($"The imbalanced node is {imbalancedNode.Name}");

            //sphbbz is the imbalanced node the difference of weight from its siblings is 9

            return (imbalancedNode.Weight - 9).ToString();
        }
    }
}
