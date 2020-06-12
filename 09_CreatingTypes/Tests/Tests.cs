using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private int countOfCycles;

        public Tests()
        {
            countOfCycles = 100000;
        } 

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroTriangleMustThrowException()
        {
            new Shapes.Triangle(0, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeASideMustThrowException()
        {
            new Shapes.Triangle(-2, 2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeBSideMustThrowException()
        {
            new Shapes.Triangle(2, -2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeCSideMustThrowException()
        {
            new Shapes.Triangle(2, 2, -2);
        }

        [TestMethod]
        public void MustCorrectCreateTriangle()
        {
            for (int i = 1; i < countOfCycles; i++)
            {
                new Shapes.Triangle(i, i, i);
            }
        }

        [TestMethod]
        public void CorrectPerimeters()
        {
            for (int i = 1; i < countOfCycles; i++)
            {
                var triangle = new Shapes.Triangle(i, i, i);
                Assert.AreEqual(3 * i, triangle.GetPerimeter());
            }
        }

        [TestMethod]
        public void CorrectAreas()
        {
            for (int i = 1; i < countOfCycles; i++)
            {
                var triangle = new Shapes.Triangle(i, i, i);
                double p = 0.5 * 3 * i;
                double area = Math.Sqrt(p*(p-i)*(p-i)*(p-i));
                Assert.AreEqual(area, triangle.GetArea());
            }
        }
    }
}
