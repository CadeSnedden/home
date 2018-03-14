using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string bye = Console.exit;
            //run an infinite loop. 
            //this loop prompts for input from the user
            //the user-input is executed as a cmd command
            //then the loop restarts
            //the loop can be exited by pressing 'ctrl' + 'c' on the keyboard
            while (true)
            {
                Console.Write("#>> "); //create the input prompt 
                string executeMe = Console.ReadLine(); //obtain user input to execute the next command
                ExecuteCommand(executeMe);
                if (executeMe == "exit")
                {
                    bye;
                }


                /* this loop never exits. this is not a good programming practice
                 * if you want to improve this, add an "if statement"
                 * if executeMe == "exit": exit the loop
                 */
            }
        }

        static void ExecuteCommand(string command)
        {
            //This function accepts a string as input
            //and then passes the command to cmd.exe /c "<user input>"

            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;

            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("output>>" + e.Data);
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("error>>" + e.Data);
            process.BeginErrorReadLine();

            process.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks
            /*string output = process.StandardOutput.ReadtoEnd();
            string error = process.StandardError.ReadtoEnd(); */

            exitCode = process.ExitCode;
            Console.WriteLine("ExitCode: {0}", process.ExitCode);

            //comment out for testing
            /*Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close(); */

        }
    }
}
