﻿using AOC2017.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Tests
{
    [TestClass]
    public class StreamGroupTests
    {
        [TestMethod]
        public void TestCaseNumber1()
        {
            var calculator = new StreamScoreCalculator();

            int score = calculator.CalculateStreamScore("{}");

            Assert.AreEqual(1, score);
        }

        [TestMethod]
        public void TestCaseNumber2()
        {
            var calculator = new StreamScoreCalculator();

            int score = calculator.CalculateStreamScore("{{{}}}");

            Assert.AreEqual(6, score);
        }

        [TestMethod]
        public void TestCaseNumber3()
        {
            var calculator = new StreamScoreCalculator();

            int score = calculator.CalculateStreamScore("{{},{}}");

            Assert.AreEqual(5, score);
        }

        [TestMethod]
        public void TestCaseNumber4()
        {
            var calculator = new StreamScoreCalculator();

            int score = calculator.CalculateStreamScore("{{},{},{{}}}");  //1 + 2 + 2 + 2 + 3

            Assert.AreEqual(10, score);
        }

        [TestMethod]
        public void TestCaseNumber5()
        {
            var calculator = new StreamScoreCalculator();

            int score = calculator.CalculateStreamScore("{{{},{},{{}}}}");

            Assert.AreEqual(16, score);
        }


        [TestMethod]
        public void TestCaseNumber6()
        {
            var calculator = new StreamScoreCalculator();

            int score = calculator.CalculateStreamScore("{<a>,<a>,<a>,<a>}");

            Assert.AreEqual(1, score);
        }

        [TestMethod]
        public void TestCaseNumber7()
        {
            var calculator = new StreamScoreCalculator();

            int score = calculator.CalculateStreamScore("{<a>,<a>,<a>,<a>}");

            Assert.AreEqual(1, score);
        }

        [TestMethod]
        public void TestCaseNumber8()
        {
            var calculator = new StreamScoreCalculator();

            int score = calculator.CalculateStreamScore("{{<ab>},{<ab>},{<ab>},{<ab>}}");

            Assert.AreEqual(9, score);
        }

        [TestMethod]
        public void TestCaseNumber9()
        {
            var calculator = new StreamScoreCalculator();

            int score = calculator.CalculateStreamScore("{{<!!>},{<!!>},{<!!>},{<!!>}}");

            Assert.AreEqual(9, score);
        }

        [TestMethod]
        public void TestCaseNumber10()
        {
            var calculator = new StreamScoreCalculator();

            int score = calculator.CalculateStreamScore("{{<a!>},{<a!>},{<a!>},{<ab>}}");

            Assert.AreEqual(3, score);
        }
    }
}
