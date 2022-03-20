using AOC2017.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Tests
{
    [TestClass]
    public class MemoryBlocksSimulatorTests
    {
        [TestMethod]
        public void TestWithFourMemoryBanks()
        {
            var initialConfiguration = new List<int> { 0, 2, 7, 0 };
            var simulator = new MemoryBlocksSimulator(initialConfiguration);
            int redistributionCount = simulator.Run();

            Assert.AreEqual(5, redistributionCount);
        }
    }
}
