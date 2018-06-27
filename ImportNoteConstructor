// creates notepad with specific lines and formatting

// program to simplify import note construction

using System;
using System.Diagnostics;
//using System.Windows.Forms;

namespace ImportNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "NOTE CONSTRUCTOR";
            Console.WriteLine(@"+----------------------------------------------------+");
            Console.WriteLine(@"| WARNING: THIS PROCESS WILL OVERWRITE ANY FILE      |");
            Console.WriteLine(@"| WITH THE NAME 'ImportNotes.txt' WITHIN FILE PATH   |");
            Console.WriteLine(@"| Do you with to continue? (y/n): " + @"                   |");
            Console.WriteLine(@"+----------------------------------------------------+");

            char sure = Console.ReadKey().KeyChar;
            if (sure == 'y') {
                Console.Clear();
                Console.WriteLine("***IMPORT NOTE CONSTRUCTOR***");
                Console.WriteLine();

                NoteCon();

                //----------------------------------------------------------------
                Console.WriteLine();
                Console.WriteLine("****Finished****");
                Console.Write("Press Enter to Continue...");
                Console.ReadLine();
            }
            else if (sure == 'n')
            {
                Console.WriteLine();
                Console.WriteLine("Exiting...");
                Console.Write("Finished. Press Enter to close window");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid options.");
                Console.WriteLine("Exiting.");
                Console.Write("Press Enter to Continue...");
            }
            Console.ReadLine();
        }
        // Creates file with format
        static void NoteCon()
        {
            Console.WriteLine();
            Console.WriteLine("Path to destination: ");
            string sPath = @"" + Console.ReadLine() + @"\" + @"ImportNotes.txt";
            Console.WriteLine();

            // creates layout array
            string[] lines = { @"IMPORTS:", @"--------------------------------------------------",
                @"MACROS TO IMPORT:" , @"" , @"####" , @"--------------------------------------------------" , @"FORMS TO IMPORT:" ,
                @"" , @"####" , @"--------------------------------------------------" , @"QUERIES TO IMPORT:" ,
                @"" , @"####" , @"--------------------------------------------------"  };

            System.IO.File.WriteAllLines(sPath, lines);

        }
    }
}

