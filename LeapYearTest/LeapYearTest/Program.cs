using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapYearTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            Console.WriteLine("This program checks whether a given year is a leap year or not. Click enter after input.\n");
            while (run) {
                Console.Write("Input Year: ");
                string yearInput = Console.ReadLine().Trim();

                int validYear = Convert.ToInt32(ValidYear(yearInput));
                CheckLeapYear(validYear);
                Console.Write("\nCheck another year (Enter 'Y' if Yes) ");
                string response = Console.ReadLine().Trim();
                run = (response.ToUpper() == "Y") ? true : false;
            }
            Console.WriteLine("\nClick Enter to Exit.");
            Console.ReadKey();
        }

        static uint ValidYear(string year)
        {
            //uint because we don't want negative years as we don't care about BCE years
            uint iYear = 0;
            bool test = true;
            string reject = "Input not valid. Input a valid year: ";

            //This will prompt the user until there is a valid input
            while (test)
            {
                if (uint.TryParse(year, out iYear))
                {
                    //There was no year 0
                    if (iYear != 0)
                    {
                        test = false;
                    }
                    else
                    {
                        Console.Write(reject);
                        year = Console.ReadLine().Trim();
                    }
                }
                else
                { 
                Console.Write(reject);
                year = Console.ReadLine().Trim();
                }
            }
            return iYear;       
        }

        static void CheckLeapYear(int year)
        {
            if (DivBy(year,400))
            {
                ResultText(year, true);
            }
            else if (DivBy(year, 100))
            {
                ResultText(year, false);
            }
            else if (DivBy(year, 4))
            {
                ResultText(year, true);
            }
            else
            {
                ResultText(year, false);
            }
        }

        static bool DivBy(int num1, int num2)
        {
            if (num1 % num2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void ResultText(int year, bool leap)
        {
            string val = leap ? " " : " NOT ";   
            Console.WriteLine("The year {0} is{1}a leap year!", year, val);
        }

    }
}
