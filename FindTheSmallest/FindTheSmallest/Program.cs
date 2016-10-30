using System;
using System.Text;

namespace FindTheSmallest
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = 205900826587298752;

            //long n = 949054622533291168;

            //long n = 97326710027329400;

            //long n = 935855753;

            //long n = 199819884756;

            //long n = 86741065181209200;

            //long n = 227090135788124416;
            //long n = 15519177548367362;

            //long n = 261235;
            //long n = 209917; 
            //long n = 285365; 
            //long n = 269045;
            //long n = 296837; 

            var arr = Smallest(n);

            Console.Write("\n\nResult: [ ");
            foreach (var item in arr)
                Console.Write(item + " ");
            Console.Write("]");

            Console.WriteLine("\n\nTap to continue...");
            Console.ReadKey(true);
        }

        public static long[] Smallest(long n)
        {
            var arr = GetDigits(n.ToString());


            //Console.Write("Get digits: ");
            //foreach (int item in arr)
            //    Console.Write(item + " ");

            var sortedArray = new int[arr.Length];
            arr.CopyTo(sortedArray, 0);
            Array.Sort(sortedArray);

            var result = new int[arr.Length];
            int newIndexOfMin = -1;
            int oldIndexOfMin = -1;
            int min = sortedArray[0];

            //Console.Write("\n\nSorted array: ");
            //foreach (int item in sortedArray)
            //    Console.Write(item + " ");

            if (arr[0] == sortedArray[sortedArray.Length - 1] && min != 0)
            {
                if (arr[arr.Length - 1] == 0)
                {
                    for (int i = 1; i < result.Length - 1; i++)
                        result[i] = arr[i + 1];

                    result[0] = 0;

                    oldIndexOfMin = arr.Length - 1;
                    newIndexOfMin = 0;
                }
                else
                {
                    for (int i = 0; i < arr.Length - 1; i++)
                        result[i] = arr[i + 1];

                    result[result.Length - 1] = sortedArray[sortedArray.Length - 1];

                    oldIndexOfMin = 0;
                    newIndexOfMin = result.Length - 1;
                }
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != sortedArray[i] || arr[i] == min)
                    {
                        newIndexOfMin = i;
                        break;
                    }
                }

                // Find old index of min
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i] == min)
                    {
                        oldIndexOfMin = i;
                        break;
                    }

                // fix it 
                if (min == 0 && oldIndexOfMin == 1)
                {
                    min = arr[0];
                    oldIndexOfMin = 0;
                    newIndexOfMin = 1;

                    arr[1] = min;
                    arr[0] = 0;
                    result = arr;
                }
                else
                {
                    // Find the last of a few min elements
                    for (int i = oldIndexOfMin + 1; i < arr.Length; i++)
                    {
                        if (arr[i] == min)
                            oldIndexOfMin = i;
                    }

                    // test
                    while (arr[oldIndexOfMin] == arr[oldIndexOfMin - 1])
                        oldIndexOfMin--;

                    //Console.Write($"\n\nIndex of the last of min elements is {oldIndexOfMin}");

                    //Console.Write($"\n\nMinnimal element is {min}");
                    //Console.Write($"\n\nNew index of the minimal element is {newIndexOfMin}");
                    //Console.Write($"\n\nOld index of min {oldIndexOfMin}");

                    for (int j = 0; j < newIndexOfMin; j++)
                        result[j] = arr[j];

                    result[newIndexOfMin] = min;

                    //Console.Write("\n\nFIRST FIRST part: ");
                    //foreach (int item in result)
                    //    Console.Write(item + " ");

                    for (int i = newIndexOfMin; i < arr.Length - 1; i++)
                    {
                        if (i < oldIndexOfMin)
                        {
                            result[i + 1] = arr[i];
                        }
                        else
                        {
                            result[i + 1] = arr[i + 1];
                        }
                    }
                }
            }

            //Console.Write("\n\nResulting array NOW NOW NOW: ");
            //foreach (int item in result)
            //    Console.Write(item + " ");

            var str = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
                str.Append(result[i]);

            long final = Convert.ToInt64(str.ToString()), startIndex = oldIndexOfMin, finalIndex = newIndexOfMin;

            return new long[] { final, startIndex, finalIndex };
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
