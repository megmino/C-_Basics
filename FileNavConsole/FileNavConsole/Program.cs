using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileNavConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string txt = ".txt";
            string folderName = @"C:\Temp5\";
            string fileName;
            string fullPath;

            //Get text file name from user
            Console.Write(" Enter a text file name then select Enter: ");
            fileName = Console.ReadLine().Trim();

            //Test for no entry and keep prompting until user enters a value
            while (string.IsNullOrEmpty(fileName)){
                Console.Write(" You did not enter a value. Please enter a text file name then select Enter: ");
                fileName = Console.ReadLine().Trim();
            }

            //Test for the correct file extension. This also catches values with no extension
            if (Path.GetExtension(fileName) != txt){
                fileName = Path.GetFileNameWithoutExtension(fileName) + txt;  
                fullPath = folderName + fileName;
                Console.WriteLine(" The file name you entered was converted to a text file: '{0}'", fileName);
            }
            else
            {
                Console.WriteLine(" You entered '{0}'", fileName);
                fullPath = folderName + fileName;
                Console.ReadKey();
            }

            //Check if the file exists. If it does, delete it and create a new one. If it does not, create the file.
            if (File.Exists(fullPath))
            {
                Console.WriteLine(" {0} already exists under {1}. Now Deleting...", fileName, folderName);
                Console.WriteLine(" Select Enter to Continue.");
                Console.ReadLine();
                File.Delete(fullPath);
                try
                {
        
                    CreateWriteToFile(fullPath);
                    Console.ReadKey();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.ReadKey();
                }
            }
            else
            {
                try
                {
                    using (FileStream filestr = File.Create(fullPath))
                    {
                        Console.WriteLine(" {0} has been created.", fullPath);                   
                    }

                    CreateWriteToFile(fullPath);
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n " + ex);
                    Console.ReadKey();
                }
            }


        }

        static void CreateWriteToFile(string sFileName)
        {
            using (StreamWriter swFileStr = File.CreateText(sFileName))
            {
                Console.Write("\n What would you like to write to the file? (one line): ");
                string sContent = Console.ReadLine().Trim();
                swFileStr.WriteLine(sContent);
                swFileStr.Dispose();
                Console.WriteLine(" {0} has been created and written to.", sFileName);
            }
            using (StreamReader srRead = File.OpenText(sFileName))
            {
                string sEmptyCheck = "";
                Console.WriteLine("\n Here are the contents of the file {0} : ", sFileName);
                while ((sEmptyCheck = srRead.ReadLine()) != null)
                {
                    Console.WriteLine("\n " + sEmptyCheck);
                }
                Console.WriteLine("\n Select Enter to exit.");
                Console.ReadKey(); 
            }

        }
    }
    }

