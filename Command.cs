using System;
using System.Diagnostics;
using static System.Console;

namespace CSTests
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * runs an infinite loop
             * this loop prompts for input from the user
             * the user-input is executed as a cmd command
             * then the loop restarts
             * the loop can be exited by pressing 'ctrl' + 'c' on keyboard
             */

            {
                do
                {
                    Console.Write("#>> "); // creates input prompt
                    string executeMe = Console.ReadLine(); // obtain user input to execute the next command
                    ExecuteCommand(executeMe);

                    if (executeMe == "exit")
                    {
                        try
                        {

                            Process cmd = new Process();
                            cmd.StartInfo.FileName = "cmd.exe";
                            cmd.EnableRaisingEvents = true;

                            cmd.Start();
                            cmd.WaitForExit();
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oops!: " + e.Message);
                            return;
                        }
                    }

                } while (true);

                /*
                 * This loop never exits. This is not good programming practice
                 * if you want to improve this, add an "if statement"
                 * if executeMe == "exit": exit the loop
                 */

               // if (executeMe == "exit")
               // {
               //     break;
               // }
            }

            Console.ReadLine();
        }
        static void ExecuteCommand(string command)
        {
            // function accepts strings as input
            // then passes command to cmd.exe /c "<user input>"
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c" + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;

            //**Redirect Output**
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("" + e.Data);
            process.BeginOutputReadLine();

            //process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
            //    Console.WriteLine("error>> " + e.Data);
            //process.BeginErrorReadLine();

            process.WaitForExit();

            exitCode = process.ExitCode;
           // Console.WriteLine("ExitCode: {0}", process.ExitCode);

        }
    }
}
