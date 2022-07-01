using AOC;
using BirdLib.ExtensionMethods;
using BirdLib.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day12PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            Graph graph = GetInputGraph();
            HashSet<int> reachableNodes = graph.GetReachableNodesFrom(0);

            return reachableNodes.Count.ToString();
        }

        private Graph GetInputGraph()
        {
            var inputFileLines = InputFilesHelper.GetInputFileLines("day12.txt");

            var edges = new List<Edge>();

            foreach (var line in inputFileLines)
            {
                List<Edge> lineEdges = ParseLineEdges(line);
                edges.AddRange(lineEdges);
            }

            var graph = new Graph(edges);
            return graph;
        }


        /// <summary>
        /// Parse edges for an input line with a format similar to:
        /// 1478 <-> 352, 788, 938, 1350, 1354
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private List<Edge> ParseLineEdges(string line)
        {
            string[] mainParts = line.Split("<->");

            int sourceNode = int.Parse(mainParts[0].Trim());

            var edges = new List<Edge>();
            string[] destinationNodes = mainParts[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (string destinationNode in destinationNodes)
            {
                var edge = new Edge(sourceNode, int.Parse(destinationNode.Trim()));
                edges.Add(edge);
            }

            return edges;
        }

        public string SolvePuzzlePart2()
        {
            Graph graph = GetInputGraph();

            int numOfGroups = 0;
            var nodesInGroups = new List<int>();

            for (int i = 0; i < 2000; i++)
            {
                if (!nodesInGroups.Contains(i))
                {
                    HashSet<int> reachableNodes = graph.GetReachableNodesFrom(i);
                    numOfGroups++;
                    nodesInGroups.AddRange(reachableNodes);
                }
            }

            return numOfGroups.ToString();
        }
    }
}
