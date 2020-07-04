using System;

namespace NewtonSQRT
{
    public static class NewtonMethods
    {
        public static double Root(double x, double n, double eps = 0.0001)
        {
            var root = x / n;
            var rn = x;
            while (Math.Abs(root - rn) >= eps)
            {
                rn = x;
                for (var i = 1; i < n; i++) rn = rn / root;
                root = 0.5 * (rn + root);
            }

            return root;
        }
    }
}