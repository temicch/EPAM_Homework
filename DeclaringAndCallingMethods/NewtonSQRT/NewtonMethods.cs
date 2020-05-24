using System;

namespace Newton
{
    public static class NewtonMethods
    {
        public static double Root(double x, double n, double eps = 0.0001)
        {
            double root = x / n;
            double rn = x;
            while (Math.Abs(root - rn) >= eps)
            {
                rn = x;
                for (int i = 1; i < n; i++)
                {
                    rn = rn / root;
                }
                root = 0.5 * (rn + root);
            }
            return root;
        }
    }
}
