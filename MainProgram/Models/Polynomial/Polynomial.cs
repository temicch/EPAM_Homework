using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polynomial
{
    public class Polynomial
    {
        private readonly List<double> array;

        /// <summary>
        /// Initializes a new polynomial with a given enumeration of coefficients
        /// </summary>
        /// <param name="arrayCoefficients">Enumeration of coefficients</param>
        public Polynomial(IEnumerable<double> arrayCoefficients)
        {
            array = new List<double>(arrayCoefficients.Reverse());
        }

        /// <summary>
        /// Initializes a new polynomial in the highest degree; in this case, all coefficients will be 0
        /// </summary>
        /// <param name="headPow">Highest Polynomial Degree</param>
        public Polynomial(int headPow)
        {
            array = new List<double>(headPow);

            for (int i = 0; i < headPow; i++)
                array.Add(0D);
        }

        /// <summary>
        /// Index polynomial coefficient access
        /// </summary>
        /// <param name="i">Polynomial coefficient number</param>
        /// <returns>Coefficient of a given order</returns>
        public double this[int i]
        {
            get
            {
                if (i < 0 || i >= array.Count)
                    throw new IndexOutOfRangeException();
                return array[i];
            }

            set
            {
                if (i < 0 || i >= array.Count)
                    throw new IndexOutOfRangeException();
                array[i] = value;
            }
        }

        /// <summary>
        /// Highest Polynomial Degree
        /// </summary>
        public int HeadPow => array.Count;

        /// <summary>
        /// Enumeration of coefficients
        /// </summary>
        public IEnumerable<double> Coefficients => array;

        public static Polynomial operator +(Polynomial poly1, Polynomial poly2)
        {
            Polynomial maxPoly = maxPowPoly(poly1, poly2);
            Polynomial minPoly = minPowPoly(poly1, poly2);

            Polynomial resultPoly = new Polynomial(maxPoly.Coefficients);

            for (int i = 0; i < minPoly.HeadPow; i++)
                resultPoly[i] = maxPoly[i] + minPoly[i];

            return resultPoly;
        }

        public static Polynomial operator -(Polynomial poly1, Polynomial poly2)
        {
            Polynomial maxPoly = maxPowPoly(poly1, poly2);
            Polynomial minPoly = minPowPoly(poly1, poly2);

            Polynomial resultPoly = new Polynomial(maxPoly.Coefficients);

            for (int i = 0; i < minPoly.HeadPow; i++)
                resultPoly[i] = maxPoly[i] - minPoly[i];

            return resultPoly;
        }

        public static Polynomial operator *(Polynomial poly1, double d)
        {
            Polynomial resultPoly = new Polynomial(poly1.Coefficients.Reverse());

            for (int i = 0; i < poly1.HeadPow; i++) 
                resultPoly[i] *= d;

            return resultPoly;
        }

        public static Polynomial operator *(Polynomial poly1, Polynomial poly2)
        {
            Polynomial resultPoly = new Polynomial(poly1.HeadPow + poly2.HeadPow - 1);

            for (int i = 0; i < poly1.HeadPow; i++)
                for (int j = 0; j < poly2.HeadPow; j++)
                    resultPoly[i + j] += poly1[i] * poly2[j];

            return resultPoly;
        }

        /// <summary>
        /// Polynomial derivative
        /// </summary>
        /// <returns>Derivative</returns>
        public Polynomial Derivative()
        {
            Polynomial result = new Polynomial(Coefficients.Reverse());

            for (int i = 0; i < HeadPow - 1; i++)
                result[i] = result[i + 1] * (i + 1);

            result.array.RemoveAt(result.HeadPow - 1);

            if (result.array.Count == 0) 
                result.array.Add(0);

            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = HeadPow - 1; i >= 0; i--)
            {
                if (this[i] == 0)
                    continue;
                if (i < HeadPow - 1)
                    result.Append(this[i] > 0 ? " + " : " - ");
                result.Append($"{Math.Abs(this[i])}*x^{i}");
            }
            return result.ToString();
        }

        /// <summary>
        /// Solve a polynomial with a given value of X
        /// </summary>
        public double GetSolution(double x)
        {
            double res = this[0];

            for (int i = 1; i < HeadPow; i++)
                res += this[i] * Math.Pow(x, i);

            return res;
        }

        private static Func<Polynomial, Polynomial, Polynomial> maxPowPoly = (x, y) =>
            Math.Max(x.HeadPow, y.HeadPow) == x.HeadPow ? x : y;

        private static Func<Polynomial, Polynomial, Polynomial> minPowPoly = (x, y) =>
            maxPowPoly(x, y).Equals(x) ? y : x;
    }
}
