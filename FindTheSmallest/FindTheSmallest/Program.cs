using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheSmallest
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = 261235;

            var arr = Smallest(n);

            Console.Write("\nResult: [ ");
            foreach (var item in arr)
                Console.Write(item + " ");
            Console.Write("]");

            Console.WriteLine("\n\nTap to continue...");
            Console.ReadKey(true);
        }

        public static long[] Smallest(long n)
        {
            var arr = GetDigits(n.ToString());

            Console.Write("Get digits: ");
            foreach (int item in arr)
                Console.Write(item + " ");

            var val = GetMinValueAndIndex(arr);
            int min = val[0];
            int indexOfMin = val[1];

            // fix it
            if(indexOfMin == 0)

            
            Console.WriteLine($"\n\nMinimal element: {min}");
            Console.WriteLine($"\nIndex of minimal element: {indexOfMin}");

            var result = new int[arr.Length];

            if (indexOfMin == 0)
            {
                result = arr;
            }
            else
            {
                var helper = new int[arr.Length - 1];

                for (int i = 0, j = 0; i < arr.Length; i++)
                    if (i != indexOfMin)
                    {
                        helper[j] = arr[i];
                        j++;
                    }

                result[0] = min;

                for (int i = 0; i < helper.Length; i++)
                    result[i + 1] = helper[i];
            }

            var str = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
                str.Append(result[i]);

            long final = Convert.ToInt64(str.ToString()), startIndex = indexOfMin, finalIndex = 0;

            return new long[] { final, startIndex, finalIndex };
        }

        public static int[] GetDigits(string number)
        {
            var digits = new int[number.Length];

            for(int i = 0; i < number.Length; i++)
                digits[i] = (int)Char.GetNumericValue(number[i]);

            return digits;
        }

        public static int[] GetMinValueAndIndex(int[] array)
        {
            var arr = new int[array.Length];
            array.CopyTo(arr, 0);
            Array.Sort(arr);

            Console.Write("\n\nSorted array: ");
            foreach (int item in arr)
                Console.Write(item + " ");

            int min = arr[0];
            int indexOfMin = -1;

            for (int i = 0; i < array.Length; i++)
                if (array[i] == min)
                {
                    indexOfMin = i;
                    break;
                }

            return new int[] {min, indexOfMin};
        }
    }
}
