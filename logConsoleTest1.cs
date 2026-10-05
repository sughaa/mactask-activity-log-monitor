using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("===== macOS Process Monitor =====");
            Console.WriteLine($"Hora: {DateTime.Now}");
            Console.WriteLine();

            ShowProcesses();

            Thread.Sleep(5000);
        }
    }

    static void ShowProcesses()
    {
        var process = new Process();

        process.StartInfo.FileName = "/bin/ps";
        process.StartInfo.Arguments = "-axo pid,ppid,user,%cpu,%mem,comm";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        process.Start();

        string output = process.StandardOutput.ReadToEnd();

        process.WaitForExit();

        Console.WriteLine(output);
    }
}