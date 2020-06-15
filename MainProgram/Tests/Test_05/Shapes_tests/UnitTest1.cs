using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShapes;

namespace Shapes_tests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly int countOfCycles;

        public UnitTest1()
        {
            countOfCycles = 100000;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroTriangleMustThrowException()
        {
            new Triangle(0, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeASideMustThrowException()
        {
            new Triangle(-2, 2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeBSideMustThrowException()
        {
            new Triangle(2, -2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeCSideMustThrowException()
        {
            new Triangle(2, 2, -2);
        }

        [TestMethod]
        public void MustCorrectCreateTriangle()
        {
            for (var i = 1; i < countOfCycles; i++) new Triangle(i, i, i);
        }

        [TestMethod]
        public void CorrectPerimeters()
        {
            for (var i = 1; i < countOfCycles; i++)
            {
                var triangle = new Triangle(i, i, i);
                Assert.AreEqual(3 * i, triangle.GetPerimeter());
            }
        }

        [TestMethod]
        public void CorrectAreas()
        {
            for (var i = 1; i < countOfCycles; i++)
            {
                var triangle = new Triangle(i, i, i);
                var p = 0.5 * 3 * i;
                var area = Math.Sqrt(p * (p - i) * (p - i) * (p - i));
                Assert.AreEqual(area, triangle.GetArea());
            }
        }
    }
}