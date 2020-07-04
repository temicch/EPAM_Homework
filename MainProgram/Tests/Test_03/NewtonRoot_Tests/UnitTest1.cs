using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewtonSQRT;

namespace NewtonRoot_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly double eps = 0.001;

        [TestMethod]
        public void SqrtShouldBeEquivalentEvery100Element()
        {
            // Every 100th element
            for (double value = 1; value < int.MaxValue / 2; value += 100)
            {
                var number = NewtonMethods.Root(value, 2);
                var expected = Math.Pow(value, 1 / (double) 2);
                Assert.AreEqual(expected, number, eps);
            }
        }

        [TestMethod]
        public void SqrtShouldBeEquivalentEvery2nElement()
        {
            // Every squad element
            for (double value = 1, i = 0; i < 64; value *= 2, i++)
            {
                var number = NewtonMethods.Root(value, 2);
                var expected = Math.Pow(value, 1 / (double) 2);
                Assert.AreEqual(expected, number, eps);
            }
        }
    }
}