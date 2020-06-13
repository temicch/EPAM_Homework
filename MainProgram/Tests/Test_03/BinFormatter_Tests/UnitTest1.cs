using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinFormatter_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PowersOfTwoShouldBeEquivalent()
        {
            for (uint i = 1; i < 32; i <<= 1)
            {
                string binFormatterString = BinFormatter.BinFormatter.IntToBinString(i);
                string netConvert = Convert.ToString(i, 2);
                Assert.AreEqual(binFormatterString, netConvert);
            }
        }

        [TestMethod]
        public void ZeroShouldBeZero()
        {
            string binFormatterString = BinFormatter.BinFormatter.IntToBinString(0);
            Assert.AreEqual(binFormatterString, "0");
        }
    }
}
