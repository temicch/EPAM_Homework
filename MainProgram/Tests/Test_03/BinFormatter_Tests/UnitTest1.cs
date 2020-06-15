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
                var binFormatterString = BinFormatter.BinFormatter.IntToBinString(i);
                var netConvert = Convert.ToString(i, 2);
                Assert.AreEqual(binFormatterString, netConvert);
            }
        }

        [TestMethod]
        public void ZeroShouldBeZero()
        {
            var binFormatterString = BinFormatter.BinFormatter.IntToBinString(0);
            Assert.AreEqual(binFormatterString, "0");
        }
    }
}