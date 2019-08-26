using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExcercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int[] a = new int[10];

            Console.Write("Read n number of values in an array and display it in reverse order of entry:\n");

            Console.Write("Input the number of elements to store in the array (10 or less) : ");
            int num = ValidNum(Console.ReadLine().Trim(), true);

            Console.Write("Input {0} number of elements into the array :\n", num);
            for (i = 0; i < num; i++)
            {
                Console.Write("element - {0} : ", i);
                a[i] = ValidNum(Console.ReadLine().Trim(), false);
            }

            Console.Write("\nThe values stored in the array are : \n");
            for (i = 0; i < num; i++)
            {
                Console.Write("{0}  ", a[i]);
            }

            Console.Write("\n\nThe values stored in the array in reverse are :\n");
            for (i = num - 1; i >= 0; i--)
            {
                Console.Write("{0} ", a[i]);
            }

            Console.ReadKey();
        }
        
        static int ValidNum (string input, bool arrMax)
        {
            int val = 0;
            bool test = true;
            while (test)
            {
                if (Int32.TryParse(input, out val))
                {
                    //Array cannot be bigger than 10 or less than/equal to 0
                    test = (arrMax && (val > 10 || val <= 0)) ? true : false;               
                }
                if (test)
                {
                    Console.Write("Enter a valid number: ");
                    input = Console.ReadLine().Trim();
                }
            }

            return val;
        }
    }
}
