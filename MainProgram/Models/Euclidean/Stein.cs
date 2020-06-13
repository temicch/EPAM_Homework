namespace Euclidean
{
    public static class Stein
    {
        public static uint Gcd(uint num1, uint num2)
        {
            uint shift = 0;

            if (num1 == 0) return num2;
            if (num2 == 0) return num1;

            while (((num1 | num2) & 1) == 0)
            {
                shift++;
                num1 >>= 1;
                num2 >>= 1;
            }

            while ((num1 & 1) == 0)
                num1 >>= 1;

            do
            {
                while ((num2 & 1) == 0)
                    num2 >>= 1;

                if (num1 > num2)
                {
                    uint t = num2;
                    num2 = num1;
                    num1 = t;
                }

                num2 -= num1;
            } while (num2 != 0);

            return num1 << (int)shift;
        }
        public static uint Gcd3(uint num1, uint num2, uint num3)
        {
            return Gcd(Gcd(num1, num2), num3);
        }
        public static uint Gcd4(uint num1, uint num2, uint num3, uint num4)
        {
            return Gcd(Gcd(Gcd(num1, num2), num3), num4);
        }
        public static uint Gcd5(uint num1, uint num2, uint num3, uint num4, uint num5)
        {
            return Gcd(Gcd(Gcd(Gcd(num1, num2), num3), num4), num5);
        }
    }
}
