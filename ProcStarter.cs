using System;
using System.Diagnostics;

namespace ProcessExitSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
		//Edit Filename to which ever file is wanting to be ran.
                Process firstProc = new Process();
                firstProc.StartInfo.FileName = "*.*";
                firstProc.EnableRaisingEvents = true;

                firstProc.Start();

                firstProc.WaitForExit();

                //You may want to perform different actions depending on the exit code.
                Console.WriteLine("First process exited: " + firstProc.ExitCode);


		//Edit the Filename to which ever file it wanting to be ran.
                Process secProc = new Process();
                secProc.StartInfo.FileName = "*.*";
                secProc.Start();                

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred!!!: " + ex.Message);
                return;
            }
        }
    }
}
