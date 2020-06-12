using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NewtonRoot_Tests
{
    [TestClass]
    public class Tests
    {
        static double eps = 0.001;

        [TestMethod]
        public void SqrtShouldBeEquivalentEvery100Element()
        {
            // Every 100th element
            for (double value = 1; value < int.MaxValue / 2; value += 100)
            {
                double number = Newton.NewtonMethods.Root(value, 2);
                double expected = Math.Pow(value, 1 / (double)2);
                Assert.AreEqual(expected, number, eps);
            }
        }

        [TestMethod]
        public void SqrtShouldBeEquivalentEvery2nElement()
        {
            // Every squad element
            for (double value = 1, i = 0; i < 64; value *= 2, i++)
            {
                double number = Newton.NewtonMethods.Root(value, 2);
                double expected = Math.Pow(value, 1 / (double)2);
                Assert.AreEqual(expected, number, eps);
            }
        }
    }
}
