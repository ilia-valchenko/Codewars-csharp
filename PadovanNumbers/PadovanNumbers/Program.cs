using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadovanNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Print padovan numbers: ");
            for (int i = 1; i < 20; i++)
                Console.WriteLine($"i: {i} and number: {Get(i)}");

            Console.WriteLine("\n\nTap to continue...");
            Console.ReadKey(true);
        }

        public static long Get(int number)
        {
            if (number < 3)
                return 1;

            int result = 0;
            var list = new List<int>();
            list.Add(number - 2);
            list.Add(number - 3);

            for(int i = 0; i < list.Count; i++)
            {
                if(list[i] >= 3)
                {
                    list.Add(list[i] - 2);
                    list.Add(list[i] - 3);
                } else
                {
                    result += 1;
                }
            }

            return result;
        }
    }
}
