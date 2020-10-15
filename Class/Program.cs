using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Comp c = new Comp(5, 2);
            Console.WriteLine(c.CheckDisk("DVD"));
            c.AddDisk(1, new HDD());
            c.AddDisk(2,new DVD());
            Console.WriteLine(c.CheckDisk("DVD"));
            Console.WriteLine();
            c.ShowDisk();
            Console.WriteLine();
            c.AddDevice(0,new Monitor());
            c.AddDevice(1,new Printer());
            c.PrintInfo("Hello Word", "Monitor");
            Console.WriteLine();
            c.ShowPrintDevice();
        }
    }
}
