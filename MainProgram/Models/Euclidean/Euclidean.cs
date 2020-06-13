namespace Euclidean
{
    public static class Euclidean
    {
        public static uint Gcd(uint num1, uint num2)
        {
            if (num1 == 0) return num2;
            if (num2 == 0) return num1;
            while (num1 != num2)
            {
                if (num1 > num2)
                {
                    num1 = num1 - num2;
                }
                else
                {
                    num2 = num2 - num1;
                }
            }
            return num1;
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
