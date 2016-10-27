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

            var arr = GetDigits(n.ToString());

            Console.Write("Get digits: ");
            foreach (int item in arr)
                Console.Write(item + " ");

            var sortedArr = GetDigits(n.ToString());
            Array.Sort(sortedArr);

            Console.Write("\n\nSorted array: ");
            foreach (int item in sortedArr)
                Console.Write(item + " ");

            int min = sortedArr[0];
            int indexOfMin = -1;

            Console.WriteLine("Minimal element is: " + min);
            

            for(int i = 0; i < arr.Length; i++)
                if(arr[i] == min)
                {
                    indexOfMin = i;
                    break;
                }

            Console.WriteLine("\nIndex of minimal element is: " + indexOfMin);

            var result = new int[arr.Length];
            
            if(indexOfMin == 0)
            {
                result = arr;
            } else
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

            Console.Write("\nResult as array: ");
            foreach (int item in result)
                Console.Write(item + " ");

            var str = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
                str.Append(result[i]);

            long final = Convert.ToInt64(str.ToString());

            Console.WriteLine($"[{final}, {indexOfMin}, 0]");

            Console.WriteLine("\n\nTap to continue...");
            Console.ReadKey(true);
        }

        public static int[] GetDigits(string number)
        {
            var digits = new int[number.Length];

            for(int i = 0; i < number.Length; i++)
                digits[i] = (int)Char.GetNumericValue(number[i]);

            return digits;
        }


    }
}
