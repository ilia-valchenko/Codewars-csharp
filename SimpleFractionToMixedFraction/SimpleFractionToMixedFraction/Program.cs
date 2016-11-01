using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFractionToMixedFraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = { /*"42 / 9", "6/3", "1/1", "11/11", "4/6", "0/18891", "-10/7"*/ "3/-64"};
            foreach (var item in array)
                Console.WriteLine(MixedFraction(item));

            Console.WriteLine("\nTap to continue...");
            Console.ReadKey(true);
        }

        public static string MixedFraction(string s)
        {
            if (s == null)
                throw new NullReferenceException();

            int numerator, denominator;
            Int32.TryParse(s.Split('/')[0], out numerator);
            Int32.TryParse(s.Split('/')[1], out denominator);

            if (denominator == 0)
                throw new DivideByZeroException();

            if (numerator == 0)
                return "0";

            if (Math.Abs(numerator) == Math.Abs(denominator))
            {
                if (numerator * denominator > 0)
                    return "1";
                else
                    return "-1";
            }
                
            if(numerator < 0 && denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            if(numerator > 0 && denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            if (Math.Abs(numerator) > Math.Abs(denominator))
            {
                if (numerator % denominator == 0)
                {
                    return (numerator / denominator).ToString();
                }
                else
                {
                    int integerPart = numerator / denominator;
                    string fractionPart = MixedFraction((Math.Abs(numerator) - denominator * Math.Abs(integerPart)).ToString() + "/" + denominator.ToString());

                    return integerPart.ToString() + " " + fractionPart;
                } 
            } else
            {
                int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));

                if(gcd != 1)
                {
                    numerator = numerator / gcd;
                    denominator = denominator / gcd;
                    return numerator.ToString() + "/" + denominator.ToString();
                }

                return numerator.ToString() + "/" + denominator.ToString();
            }
        }

        public static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
