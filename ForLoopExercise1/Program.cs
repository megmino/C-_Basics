using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLoopExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            Console.Write("Display the cube of the number:\n");
            Console.Write("\n\n");
            Console.Write("Input number of terms : ");
            var num = ValidNumber(Console.ReadLine().Trim());
            for (i = 1; i <= num; i++)
            {
                Console.Write("Number is : {0} and cube of {0} is :{1} \n", i, (Math.Pow(i,3)));
            }
            Console.ReadKey();
        }

        static int ValidNumber(string input)
        {
            int val = 0;
            bool test = true;
            while (test)
            {
                if (Int32.TryParse(input, out val))
                {
                    test = false;
                }
                else
                {
                    Console.Write("Invalid Input. Please enter valid number: ");
                    input = Console.ReadLine().Trim();
                }
            }
            return val;
        }

    }
    
}
