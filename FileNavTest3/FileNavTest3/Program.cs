using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNavTest3
{
    class Program
    {
        static void Main(string[] args)
        {
            // To move a file to a new location:
            string sourceFile = @"C:\Temp5\public\test501.txt";
            string destinationFile = @"C:\Temp5\private\test501.txt";
            MoveFile(sourceFile, destinationFile);

            //To move all the files from one folder to another
            string sourceFolder = @"C:\Temp5\public";
            string destinationFolder = @"C:\Temp5\private";

            if (Directory.Exists(sourceFolder))
            {
                if (Directory.Exists(destinationFolder))
                {
                    MoveDir(sourceFolder, destinationFolder);
                }
                else
                {
                    Directory.CreateDirectory(destinationFolder);
                    MoveDir(sourceFolder, destinationFolder);
                }
            }
            else
            {
                Console.Write("Source Folder does not exist.");
            }
            Console.ReadKey();
        }

        static void MoveFile(string sourceFile, string destinationFile)
        {
            if (File.Exists(sourceFile) & Directory.Exists(Path.GetDirectoryName(destinationFile)))
            {
                Console.Write(" Source file {0} exists \n Directory {1} exists. \n Moving file.", sourceFile, Path.GetDirectoryName(destinationFile));
                try
                {
                    File.Move(sourceFile, destinationFile);
                    Console.Write(" File Succesfully Moved.\n");
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
            else
            {
                Console.Write(" Source or Destination did not exist. File not moved.\n");
            }
            Console.ReadKey();
        }

        static void MoveDir(string sourceFolder, string destFolder)
        {
            
            string[] sourceFiles = Directory.GetFiles(sourceFolder);
            string[] destFiles = Directory.GetFiles(destFolder);
            foreach (string sFile in sourceFiles)
            {

                //Check for files with the same name in destination
                bool ind = false;
                foreach (string dFile in destFiles)
                {
                    if (Path.GetFileName(sFile) == Path.GetFileName(dFile))
                    {
                        ind = true;
                    }   
                }

                //Move the file if no files exist in destination folder with the same name
                if (ind)
                {
                    Console.Write("\n {0} was not moved. File with same name exists in destination.", Path.GetFileName(sFile));
                }
                else
                {
                    string dest = Path.Combine(destFolder, Path.GetFileName(sFile));
                    File.Move(sFile, dest);
                    Console.Write("\n {0} was moved.", Path.GetFileName(sFile));
                }

            }
        }
    }
}
