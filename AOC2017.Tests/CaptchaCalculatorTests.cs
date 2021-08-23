using AOC2017.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC2017.Tests
{
    [TestClass]
    public class CaptchaCalculatorTests
    {
        [TestMethod]
        public void TestCase1()
        {
            var captachCalculator = new CaptchaCalculator();

            int captcha = captachCalculator.CalculateCaptch("1122");

            Assert.AreEqual(3, captcha);
        }

        [TestMethod]
        public void TestCase2()
        {
            var captachCalculator = new CaptchaCalculator();

            int captcha = captachCalculator.CalculateCaptch("1111");

            Assert.AreEqual(4, captcha);
        }


        [TestMethod]
        public void TestCase3()
        {
            var captachCalculator = new CaptchaCalculator();

            int captcha = captachCalculator.CalculateCaptch("1234");

            Assert.AreEqual(0, captcha);
        }

        [TestMethod]
        public void TestCase4()
        {
            var captachCalculator = new CaptchaCalculator();

            int captcha = captachCalculator.CalculateCaptch("91212129");

            Assert.AreEqual(9, captcha);
        }

        [TestMethod]
        public void TestAdvancedCase1()
        {
            var captachCalculator = new CaptchaCalculator();

            int captcha = captachCalculator.CalculateAdvancedCaptch("1212");

            Assert.AreEqual(6, captcha);
        }

        [TestMethod]
        public void TestAdvancedCase2()
        {
            var captachCalculator = new CaptchaCalculator();

            int captcha = captachCalculator.CalculateAdvancedCaptch("1221");

            Assert.AreEqual(0, captcha);
        }

        [TestMethod]
        public void TestAdvancedCase3()
        {
            var captachCalculator = new CaptchaCalculator();

            int captcha = captachCalculator.CalculateAdvancedCaptch("123425");

            Assert.AreEqual(4, captcha);
        }

        [TestMethod]
        public void TestAdvancedCase4()
        {
            var captachCalculator = new CaptchaCalculator();

            int captcha = captachCalculator.CalculateAdvancedCaptch("123123");

            Assert.AreEqual(12, captcha);
        }

        [TestMethod]
        public void TestAdvancedCase5()
        {
            var captachCalculator = new CaptchaCalculator();

            int captcha = captachCalculator.CalculateAdvancedCaptch("12131415");

            Assert.AreEqual(4, captcha);
        }
    }
}
