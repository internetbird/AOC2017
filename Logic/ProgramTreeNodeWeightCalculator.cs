using AOC2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class ProgramTreeNodeWeightCalculator
    {
        private Dictionary<string, int> _weightsDictionary;

        public ProgramTreeNodeWeightCalculator()
        {
            _weightsDictionary = new Dictionary<string, int>();
        }

        public void CalculateNodesWeight(List<ProgramTreeNode> nodes)
        {
            while(_weightsDictionary.Count < nodes.Count)
            {
                foreach (ProgramTreeNode node in nodes)
                {
                    if (!_weightsDictionary.ContainsKey(node.Name))
                    {
                        if (node.SubProgramsNames == null)
                        {
                            _weightsDictionary.Add(node.Name, node.Weight);
                        } else
                        {
                            if (node.SubProgramsNames.All(subName => _weightsDictionary.ContainsKey(subName)))
                            {
                                int totalWeight = node.Weight;

                                node.SubProgramsNames.ForEach(subName => totalWeight += _weightsDictionary[subName]);

                                _weightsDictionary.Add(node.Name, totalWeight);
                            }
                        }
                    }
                }
            }
        }


        public int GetWeightForNode(string nodeName)
        {
            return _weightsDictionary[nodeName];
        }
    }
}
