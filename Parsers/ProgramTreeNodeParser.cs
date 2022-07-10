using AOC2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class ProgramTreeNodeParser
    {
        /// <summary>
        /// Parse an input with a format similar to: boofr (332) -> aqiun, zilgfzu
        /// </summary>
        /// <param name="inputLine"></param>
        /// <returns></returns>
        public ProgramTreeNode ParseLine(string inputLine)
        {
            string[] lineParts = inputLine.Split("->");

            var programTreeNode = new ProgramTreeNode();

            (string name, int weight) = ParseNamePart(lineParts[0]);

            programTreeNode.Name = name;
            programTreeNode.Weight = weight;

            if (lineParts.Length > 1)
            {
                List<string> subProgramName = ParseSubPrograms(lineParts[1]);
                programTreeNode.SubProgramsNames = subProgramName;
            }

            return programTreeNode;
        }

        private (string name, int weight) ParseNamePart(string namePart)
        {
            string[] parts = namePart.Split(' ');

            int weight = int.Parse(Regex.Replace(parts[1], @"[()]", string.Empty));

            return (parts[0], weight);
        }

        private List<string> ParseSubPrograms(string subProgramsPart)
        {
           List<string> subProgramNames =  subProgramsPart.Split(',').Select(name => name.Trim()).ToList();
            return subProgramNames;
        }
       
    }
}
