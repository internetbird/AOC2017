using AOC2017.Logic;
using AOC2017.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Tests
{
    [TestClass]
    public class ProgramTreeNodeWeightCalculatorTests
    {
        [TestMethod]
        public void WeightCalculatorTest1()
        {
            List<ProgramTreeNode> inputTreeNodes = GetInputTreeNodes();

            var weightCalculator = new ProgramTreeNodeWeightCalculator();

            weightCalculator.CalculateNodesWeight(inputTreeNodes);

            Assert.AreEqual(251, weightCalculator.GetWeightForNode("ugml"));
            Assert.AreEqual(243, weightCalculator.GetWeightForNode("padx"));
        }

        private List<ProgramTreeNode> GetInputTreeNodes()
        {

            return new List<ProgramTreeNode>
           {
                new ProgramTreeNode{Name = "pbga", Weight=66},
                new ProgramTreeNode{Name = "xhth", Weight=57},
                new ProgramTreeNode{Name = "ebii", Weight=61},
                new ProgramTreeNode{Name = "havc", Weight=66},
                new ProgramTreeNode{Name = "ktlj", Weight=57},
                new ProgramTreeNode{Name = "fwft", Weight=72, SubProgramsNames = new List<string>{"ktlj", "cntj", "xhth"} },
                new ProgramTreeNode{Name = "qoyq", Weight=66},
                new ProgramTreeNode{Name = "padx", Weight=45, SubProgramsNames = new List<string>{ "pbga", "havc", "qoyq"} },
                new ProgramTreeNode{Name = "tknk", Weight=41,SubProgramsNames = new List<string>{ "ugml", "padx", "fwft" } },
                new ProgramTreeNode{Name = "jptl", Weight=61},
                new ProgramTreeNode{Name = "ugml", Weight=68, SubProgramsNames = new List<string>{ "gyxo", "ebii", "jptl" }},
                new ProgramTreeNode{Name = "gyxo", Weight=61},
                new ProgramTreeNode{Name = "cntj", Weight=57}
           };
        }
    }
}
