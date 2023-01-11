using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkPortScanner;
public class PortsChecker
{
    private string host;
    private readonly PortLists portLists;
    public PortsChecker(string Host, int postStrat, int portStop)
    {
        host = Host;
        portLists = new PortLists(postStrat, portStop);
    }
    public void StartChecking(int threadCounter)
    {
        for (var i = 0; i < threadCounter; i++)
        {
            Thread thread1 = new Thread(new ThreadStart(StartScanningTcp));
            thread1.Start();
        }
    }
    public void StartScanningTcp()
    {
        int port;
        TcpClient tcp = new TcpClient();
        while ((port = portLists.NextPorts()) != -1)
        {
            Console.Title = "Current Port Count : " + port.ToString();
            try
            {
                tcp = new TcpClient(host, port);
            }
            catch (Exception ex)
            {
                continue;
            }
            finally
            {
                try
                {
                    tcp.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Tcp Port {0} is open", port);
            }
        }
    }
}
