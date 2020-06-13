using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shapes_tests
{
    [TestClass]
    public class UnitTest1
    {
        private int countOfCycles;

        public UnitTest1()
        {
            countOfCycles = 100000;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroTriangleMustThrowException()
        {
            new MyShapes.Triangle(0, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeASideMustThrowException()
        {
            new MyShapes.Triangle(-2, 2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeBSideMustThrowException()
        {
            new MyShapes.Triangle(2, -2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeCSideMustThrowException()
        {
            new MyShapes.Triangle(2, 2, -2);
        }

        [TestMethod]
        public void MustCorrectCreateTriangle()
        {
            for (int i = 1; i < countOfCycles; i++)
            {
                new MyShapes.Triangle(i, i, i);
            }
        }

        [TestMethod]
        public void CorrectPerimeters()
        {
            for (int i = 1; i < countOfCycles; i++)
            {
                var triangle = new MyShapes.Triangle(i, i, i);
                Assert.AreEqual(3 * i, triangle.GetPerimeter());
            }
        }

        [TestMethod]
        public void CorrectAreas()
        {
            for (int i = 1; i < countOfCycles; i++)
            {
                var triangle = new MyShapes.Triangle(i, i, i);
                double p = 0.5 * 3 * i;
                double area = Math.Sqrt(p * (p - i) * (p - i) * (p - i));
                Assert.AreEqual(area, triangle.GetArea());
            }
        }
    }
}
