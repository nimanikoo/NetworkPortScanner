using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace NetworkPortScanner;
public class PortLists
{
    private int start;
    private int stop;
    private int ports;
    public PortLists(int starts, int stops)
    {
        start = starts;
        stop = stops;
        ports = start;
    }
    public bool MorePorts()
    {
        return stop - ports >= 0;
    }
    public int NextPorts()
    {
        if (MorePorts())
        {
            return ports++;
        }
        return -1;
    }
}
