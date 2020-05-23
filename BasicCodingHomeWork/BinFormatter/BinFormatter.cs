using System.Text;

namespace BinFormatter
{
    public static class BinFormatter
    {
        public static string IntToBinString(uint value)
        {
            if (value == 0)
                return 0.ToString();
            StringBuilder result = new StringBuilder(32);
            while(value > 0)
            {
                result.Insert(0, value & 1);
                value >>= 1;
            }
            return result.ToString();
        }
    }
}
