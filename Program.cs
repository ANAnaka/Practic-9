using System.Diagnostics;
static void Main(string[] args)
{
    string a;
intro:
    Console.WriteLine("OPTIONS:");
    Console.WriteLine("1. Start Process");
    Console.WriteLine("2. View Process");
    Console.WriteLine("3. Terminate a Process");
    Console.Write("Enter Option:");
    a = Console.ReadLine();
    if (a == "1") goto start;
    if (a == "2") goto view;
    if (a == "3") goto terminate;
    Console.WriteLine("Invalid option!");
    goto intro;
start:
    {
        Console.WriteLine("Enter Process name:");
        a = Console.ReadLine();
        Process.Start(a);
        goto intro;
    }
view:
    {
        Console.WriteLine("OPTIONS for View:");
        Console.WriteLine("a. View all");
        Console.WriteLine("b. View Applications");
        Console.WriteLine("c. View Background process");
        Console.WriteLine("d. View System Process");
        Console.Write("Enter Option:");
        a = Console.ReadLine();
        if (a == "a") goto a;
        if (a == "b") goto b;
        a:
        {
            Console.WriteLine("Processes");
            Process[] processes = Process.GetProcesses();
            Console.WriteLine("No. Of Pocess: {0}", processes.Length);
            foreach (Process process in processes)
            {
                Console.WriteLine(process.ProcessName);
            }
            goto intro;
        }

    b: Apps;
    c: background Process;
    d: System process;
            }
            terminate:
{
    Console.WriteLine("Enter process name:");
    a = Console.ReadLine();
    foreach (var process in Process.GetProcessesByName(a))
    {
        process.Kill();

    }
    Console.WriteLine("Process terminated!");
    goto intro;
}
        }

public static void ListAllProcess()
{
    int processCount = 0;
    Process[] processList = Process.GetProcesses();


    foreach (Process process in processList)
    {
        Console.WriteLine("Process: {0} <> ID: {1}", process.ProcessName, process.Id);
        processCount += 1;
    }
    Console.WriteLine("Number of Total Process: {0} ", processCount);
}

static void Main(string[] args)
{


    ListAllProcess();

    try
    {

        Console.Write("\n\nDrag-Drop or enter a full path of a executable file: ");
        string applicationPath = Console.ReadLine();
        Process.Start(applicationPath);

        Console.WriteLine("'{0}' is started.", applicationPath);


        Console.Write("\n\n\n");
        ListAllProcess();

    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: '{0}'", ex);
    }


    try
    {

        Console.Write("\n\nEnter a Process ID:");
        int processID = Convert.ToInt32(Console.ReadLine());
        Process.GetProcessById(processID).Kill();
        Console.WriteLine("Process '{0}' died.", processID);
        Console.Write("\n\n\n");
        ListAllProcess();
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: '{0}'", ex);
    }

    Console.ReadLine();
}