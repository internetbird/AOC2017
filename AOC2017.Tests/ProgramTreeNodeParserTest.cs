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
    public class ProgramTreeNodeParserTest
    {
        [TestMethod]
        public void ParserTest1()
        {
            var parser = new ProgramTreeNodeParser();

            var inputLine = "boofr (332) -> aqiun, zilgfzu";

            ProgramTreeNode programTreeNode = parser.ParseLine(inputLine);

            Assert.AreEqual("boofr", programTreeNode.Name);
            Assert.AreEqual(332, programTreeNode.Weight);
            Assert.IsTrue(programTreeNode.SubProgramsNames.Contains("zilgfzu"));
        }

        [TestMethod]
        public void ParserTest2()
        {
            var parser = new ProgramTreeNodeParser();

            var inputLine = "tmybiz (55)";

            ProgramTreeNode programTreeNode = parser.ParseLine(inputLine);
            Assert.AreEqual("tmybiz", programTreeNode.Name);
            Assert.AreEqual(55, programTreeNode.Weight);
            Assert.IsNull(programTreeNode.SubProgramsNames);

        }
    }
}
