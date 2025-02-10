using System.Diagnostics;

public class Program
{
    public static void StartProcess(string processName, string arguments = "", string verb = "open", bool quitChild = false)
    {
        try
        {
            // Création d'un nouveau processus
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = processName,
                Arguments = arguments,
                Verb = verb,
                UseShellExecute = true
            };

            Process process = new Process
            {
                StartInfo = startInfo
            };

            process.EnableRaisingEvents = true;
            process.Exited += (sender, e) =>
            {
                Console.WriteLine($"Processus {process.ProcessName} n° {process.Id} s'est fermé.");
            };

            // Démarrer le processus
            process.Start();
            Console.WriteLine($"Processus {process.ProcessName} n° {process.Id} lancé avec succès.");
            process.WaitForExit();


            if (process.ProcessName != "explorer.exe")
            {
                //while (Process.GetProcessesByName(process.ProcessName.Replace(".exe", "")).Any())
                if (quitChild)
                {
                    Thread.Sleep(4000);
                    process.Kill();
                    Console.WriteLine($"Fermeture du processus {process.ProcessName} n° {process.Id}.");
                }
                else
                {
                    process.WaitForExit();
                }
            }

            // Attente de 2 secondes avant de continuer
            Thread.Sleep(2000);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur lors du lancement du processus : " + ex.Message);
        }
    }

    public static void displayProcesses()
    {
        Console.WriteLine("=== Processus =====================================================================");
        Console.WriteLine($"PID   | {"Name",-40} | {"Priority",-8} | {"Mem Paged",-9} | {"Mem NonPaged",-9}");
        foreach (var process in Process.GetProcesses())
        {
            Console.WriteLine($"{process.Id:D5} | {process.ProcessName,-40} | {process.BasePriority,8} | {process.PagedMemorySize64,9} | {process.NonpagedSystemMemorySize64,9}");
        }
        Console.WriteLine("===================================================================================");
    }

    public static void Main(string[] args)
    {
        displayProcesses();

        //StartProcess("explorer.exe", "C:\\Windows", "explore");
        //StartProcess("C:/Windows/win.ini", "", "edit");

        //StartProcess("notepad++.exe", "C:\\TEST\\SauvegardeTrucs\\hqrsqgqsdgqd.txt", "", false);
    }
}