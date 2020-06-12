using System;

namespace Shapes
{
    public class Triangle
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        /// <summary>
        /// Creates an instance of a triangle with three specified sides.
        /// </summary>
        /// <param name="a">Side of triangle</param>
        /// <param name="b">Side of triangle</param>
        /// <param name="c">Side of triangle</param>
        public Triangle(double a, double b, double c)
        {
            if(a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("The triangle must have positive sides.");
            }
            if (!IsCorrectTriangle(a, b, c, out char wrongSide))
                throw new ArgumentException($"Wrong sides of a triangle: Side '{wrongSide}' is greater than or equal to the sum of the other two sides.");
            A = a;
            B = b;
            C = c;
        }
        /// <summary>
        /// Each side of the triangle should not be greater than or equal to the sum of the other two sides.
        /// </summary>
        /// <param name="a">Side of triangle</param>
        /// <param name="b">Side of triangle</param>
        /// <param name="c">Side of triangle</param>
        /// <param name="wrongSide">The variable is used to write the wrong side.</param>
        /// <returns></returns>
        private static bool IsCorrectTriangle(double a, double b, double c, out char wrongSide)
        {
            wrongSide = '\0';
            if (a + b > c)
                if (a + c > b)
                    if (b + c > a)
                        return true;
                    else
                        wrongSide = 'a';
                else
                    wrongSide = 'b';
            else
                wrongSide = 'c';
            return false;
        }
        /// <summary>
        /// The perimeter of the triangle is calculated using the formula of the sum of three sides.
        /// </summary>
        /// <returns></returns>
        public double GetPerimeter()
        {
            return A + B + C;
        }
        /// <summary>
        /// The area of ​​the triangle is calculated using the Heron formula.
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            // Semipertimeter
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }
}
