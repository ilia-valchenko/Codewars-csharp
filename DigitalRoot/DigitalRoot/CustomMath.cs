using System;

namespace DigitalRoot
{
    public static class CustomMath
    {
        public static int DigitalRoot(long n)
        {
            while (n.ToString().Length >= 2)
            {
                long a = (long)Char.GetNumericValue(n.ToString()[0]);

                for (int i = 1; i < n.ToString().Length; i++)
                    a += (int)Char.GetNumericValue(n.ToString()[i]);

                n = a;
            }

            return (int)n;
        }
    }
}
