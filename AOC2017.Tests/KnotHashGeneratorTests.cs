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
    public class KnotHashGeneratorTests
    {
        [TestMethod]
        public void Test1()
        {
            var hashGenerator = new KnotHashGenerator(5);

            var inputLengths = new List<int> { 3, 4, 1, 5 };
            var expectedResult = new List<int> { 3, 4, 2, 1, 0 };

            List<int> hashResult = hashGenerator.GenerateHash(inputLengths);

            Assert.IsTrue(hashResult.SequenceEqual(expectedResult));
        }
    }
}
