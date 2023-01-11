using System.Transactions;

namespace NetworkPortScanner;
internal class Program
{
    static void Main(string[] args)
    {
        string host;
        int portStart;
        int portStop;
        int Threads;
        string ipAddress;
        Console.WriteLine("Enter Host or IP or Domain : ");
        ipAddress = Console.ReadLine();
        Console.WriteLine();
        host = ipAddress;

        string StartPort;
        Console.WriteLine("Minimum start Port : 1 ");
        Console.WriteLine("Enter start Port : ");
        StartPort = Console.ReadLine();
        Console.WriteLine();

        int number;
        bool startResult = int.TryParse(StartPort, out number);

        if (startResult)
        {
            portStart = int.Parse(StartPort);
        }
        else
        {
            Console.WriteLine("Please try again...");
            return;
        }
        string endPort;
        Console.WriteLine("Maximum end Port : 65535");
        Console.WriteLine("Enter end Port : ");
        endPort = Console.ReadLine();
        Console.WriteLine();

        int number2;
        bool endResult = int.TryParse(endPort, out number2);

        if (endResult)
        {
            portStop = int.Parse(endPort);
        }
        else
        {
            Console.WriteLine("Please try again...");
            return;
        }

        string ThreadsToRun;
        Console.WriteLine("Enter how many threads needs to run : ");
        ThreadsToRun = Console.ReadLine();
        Console.WriteLine();

        int number3;
        bool threadResult = int.TryParse(ThreadsToRun, out number3);

        if (threadResult)
        {
            Threads = int.Parse(ThreadsToRun);
        }
        else
        {
            Console.WriteLine("Please try again...");
            return;
        }
        if (startResult == true && endResult == true)
        {
            try
            {
                portStart = int.Parse(StartPort);
                portStop = int.Parse(endPort);
            }
            catch (Exception ex)
            {

                return;
            }
        }
        if (threadResult == true)
        {
            try
            {
                Threads = int.Parse(ThreadsToRun);
            }
            catch (Exception ex)
            {

                return;
            }
        }
        PortsChecker pCheck = new PortsChecker(host, portStart, portStop);
        pCheck.StartChecking(Threads);
    }
}