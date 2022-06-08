using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Tests
{
    [TestClass]
    public class RoslynCompilerTest
    {
        [TestMethod]
        public async Task SimpleAssignmentTest()
        {
            var code = "var a = 2; return a > 1;";
            var result = await CSharpScript.RunAsync(code);

            Assert.AreEqual(true, result.ReturnValue);
        }
    }
}
