using Euclidean;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euclidean_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Gcd2QuadsShouldBeEquivalent()
        {
            for (uint i = 1, j = 1; i < 32; j <<= 1, i++)
            {
                var euclidGcd = Euclidean.Euclidean.Gcd(j, j / 2);
                var steinGcd = Stein.Gcd(j, j / 2);
                Assert.AreEqual(euclidGcd, steinGcd);
            }
        }

        [TestMethod]
        public void Gcd2ZeroInArgumentsMustBeZeroOutput()
        {
            var euclidGcd = Euclidean.Euclidean.Gcd(0, 0);
            var steinGcd = Stein.Gcd(0, 0);
            Assert.AreEqual(euclidGcd, steinGcd);
            Assert.AreEqual(euclidGcd, (uint) 0);
        }

        [TestMethod]
        public void Gcd3QuadsShouldBeEquivalent()
        {
            for (uint i = 1, j = 1; i < 32; j <<= 1, i++)
            {
                var euclidGcd = Euclidean.Euclidean.Gcd3(j, j / 2, j / 2);
                var steinGcd = Stein.Gcd3(j, j / 2, j / 2);
                Assert.AreEqual(euclidGcd, steinGcd);
            }
        }

        [TestMethod]
        public void Gcd3ZeroInArgumentsMustBeZeroOutput()
        {
            var euclidGcd = Euclidean.Euclidean.Gcd3(0, 0, 0);
            var steinGcd = Stein.Gcd3(0, 0, 0);
            Assert.AreEqual(euclidGcd, steinGcd);
            Assert.AreEqual(euclidGcd, (uint) 0);
        }

        [TestMethod]
        public void Gcd4QuadsShouldBeEquivalent()
        {
            for (uint i = 1, j = 1; i < 32; j <<= 1, i++)
            {
                var euclidGcd = Euclidean.Euclidean.Gcd4(j, j / 2, j / 2, j / 2);
                var steinGcd = Stein.Gcd4(j, j / 2, j / 2, j / 2);
                Assert.AreEqual(euclidGcd, steinGcd);
            }
        }

        [TestMethod]
        public void Gcd4ZeroInArgumentsMustBeZeroOutput()
        {
            var euclidGcd = Euclidean.Euclidean.Gcd4(0, 0, 0, 0);
            var steinGcd = Stein.Gcd4(0, 0, 0, 0);
            Assert.AreEqual(euclidGcd, steinGcd);
            Assert.AreEqual(euclidGcd, (uint) 0);
        }

        [TestMethod]
        public void Gcd5QuadsShouldBeEquivalent()
        {
            for (uint i = 1, j = 1; i < 32; j <<= 1, i++)
            {
                var euclidGcd = Euclidean.Euclidean.Gcd5(j, j / 2, j / 2, j / 2, j / 2);
                var steinGcd = Stein.Gcd5(j, j / 2, j / 2, j / 2, j / 2);
                Assert.AreEqual(euclidGcd, steinGcd);
            }
        }

        [TestMethod]
        public void Gcd5ZeroInArgumentsMustBeZeroOutput()
        {
            var euclidGcd = Euclidean.Euclidean.Gcd5(0, 0, 0, 0, 0);
            var steinGcd = Stein.Gcd5(0, 0, 0, 0, 0);
            Assert.AreEqual(euclidGcd, steinGcd);
            Assert.AreEqual(euclidGcd, (uint) 0);
        }
    }
}