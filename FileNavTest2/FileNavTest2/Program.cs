using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNavTest2
{
    class Program
    {
        /*Create the 'Temp' folder under your C Drive 
         OR If you have another main file path you want to use, insert in the path below */
        const string mainDirectory = @"C:\Temp\";
        static void Main(string[] args)
        {
            //Get Folder Name
            Console.Write(" Enter folder name under {0}",mainDirectory);
            string folderName = Console.ReadLine().Trim();
            folderName = ValidName(folderName, false);

            //Get File Name
            Console.Write(" Enter file name: ");
            string fileName = Console.ReadLine().Trim();
            fileName = ValidName(fileName, true);

            //Get Full Path
            string fullPath = folderName + fileName;

            //Create File and Directory
            CreateDirectory(folderName);
            CreateFile(fullPath);
            Console.ReadKey();
        }

        static void CreateDirectory(string sfolderName)
        {
            //Creating Directory
            DirectoryInfo dir = new DirectoryInfo(sfolderName);
            try
            {
                //Check If Directory Exists
                if (dir.Exists)
                {
                    Console.WriteLine(" \n\n Directory Already Exists");
                    DisplayInfo(dir);
                }
                //Create New Directory
                else
                {
                    dir.Create();
                    Console.WriteLine(" \n\n Directory Created Successfully. Information of Directory:");
                    DisplayInfo(dir);
                }
            }
            catch (DirectoryNotFoundException d)
            {
                Console.WriteLine(d.Message.ToString());
            }
        }

        static void CreateFile(string sfullPath)
        {
            try { 
            if (File.Exists(sfullPath)) {
                Console.WriteLine(" \n\n File Already Exists");
                FileInfo fileInfo = new FileInfo(sfullPath);
                DisplayInfo(fileInfo);
                }
            else
            {
                using (FileStream filestr = File.Create(sfullPath))
                {
                    Console.WriteLine(" \n\n File Created Successfully. Information of File:");
                }
                FileInfo fileInfo = new FileInfo(sfullPath);
                DisplayInfo(fileInfo);
            }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            }

        static void DisplayInfo(FileInfo fileInfo)
        {
            Console.WriteLine(" File Name : {0}", fileInfo.Name);
            Console.WriteLine(" Path : " + fileInfo.FullName);
            Console.WriteLine(" File created on : {0}", fileInfo.CreationTime);
            Console.WriteLine(" File Last Accessed on {0}", fileInfo.LastAccessTime);
        }

        static void DisplayInfo(DirectoryInfo dirInfo)
        {
            Console.WriteLine(" Directory Name : {0}", dirInfo.Name);
            Console.WriteLine(" Path : " + dirInfo.FullName);
            Console.WriteLine(" Directory created on : {0}", dirInfo.CreationTime);
            Console.WriteLine(" Directory Last Accessed on {0}", dirInfo.LastAccessTime);
        }

        static string ValidName(string sName, bool bFileCheck)
        {
            string sReturnValue = "";
            while (string.IsNullOrEmpty(sName) || sName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                Console.Write(" Please enter a valid name then select Enter: ");
                sName = Console.ReadLine().Trim();
            }

            if (bFileCheck) {
                while (Path.GetExtension(sName) != ".txt")
                {
                    sName = Path.GetFileNameWithoutExtension(sName) + ".txt";
                    Console.WriteLine(" File name converted to text file.");
                }
                sReturnValue = sName;
            }
            else
            {
                sReturnValue = mainDirectory + sName + "\\";
            }
            return sReturnValue;
        }


    }
            
    }

