using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    class Disk : IDisk
    {
        string memory;
        int memSize;
        public string Memory
        {
            get => memory;
            set => memory = value;
        }
        public int MemSize
        {
            get => MemSize;
            set => MemSize = value;
        }
        public Disk() { }
        public Disk(string memory, int memSize)
        {
            Memory = memory;
            MemSize = memSize;
        }
        virtual public string GetName() 
        {
            return "Disk";
        }
        public string Read()
        {
            throw new NotImplementedException();
        }
        public void Write(string text)
        {
            throw new NotImplementedException();
        }
    }
    class CD : Disk, IRemoveableDisk
    {
        bool hasDisk;
        public bool HasDisk => hasDisk;
        public override string GetName()
        {
            return "CD";
        }
        public void Insert()
        {
            Console.WriteLine("Insert a CD");
        }
        public void Reject()
        {
            Console.WriteLine("Reject a CD");
        }
    }
    class Flash : Disk, IRemoveableDisk
    {
        bool hasDisk;
        public bool HasDisk => hasDisk;
        public override string GetName()
        {
            return "Flash";
        }
        public void Insert()
        {
            Console.WriteLine("Insert a Flash");
        }
        public void Reject()
        {
            Console.WriteLine("Reject a Flash");
        }
    }
    class HDD : Disk
    {
        public override string GetName()
        {
            return "HDD";
        }
    }
    class DVD : Disk, IRemoveableDisk
    {
        bool hasDisk;
        public bool HasDisk => hasDisk;
        public override string GetName()
        {
            return "DVD";
        }
        public void Insert()
        {
            Console.WriteLine("Insert a DVD");
        }
        public void Reject()
        {
            Console.WriteLine("Reject a DVD");
        }
    }
    class Printer : IPrintInformation
    {
        public string GetName()
        {
            return "Printer";
        }
        public void Print(string str)
        {
            Console.WriteLine("Printer : " + str);
        }
    }
    class Monitor : IPrintInformation
    {
        public string GetName()
        {
            return "Monitor";
        }
        public void Print(string str)
        {
            Console.WriteLine("Monitor : " + str);
        }
    }
    class Comp
    {
        readonly int countDisk;
        readonly int countPrintDevice;
        Disk[] disks ;
        IPrintInformation[] printDevice;
        public void AddDevice(int index, IPrintInformation si)
        {
            if (index <= printDevice.Length)
            {
              if (printDevice.Length<index+1)
              {
              Array.Resize(ref printDevice, index+1);
              }
              printDevice[index] = si;
            }
        }
        public void AddDisk(int index, Disk d)
        {
            if (index <= printDevice.Length)
            {                
                if (disks.Length < index + 1)
                {
                    Array.Resize(ref disks, index + 1);
                }
                disks[index] = d;
            }
        }
        public bool CheckDisk(string device)
        {
            foreach (Disk d in disks)
            {
                if (d?.GetName() == device)
                {
                    return true;
                }
            }
            return false;
        }
        public void InsertReject(string device, bool b)
        {
            foreach (Disk d in disks)
            {
                if (d?.GetName() == device)
                {
                    switch (d)
                    {
                       case CD:
                            if (b)
                            {
                                ((CD)d).Insert();
                            }
                            else
                            {
                                ((CD)d).Reject();
                            }
                            break;
                        case Flash:
                            if (b)
                            {
                                ((Flash)d).Insert();
                            }
                            else
                            {
                                ((Flash)d).Reject();
                            }
                            break;
                        case DVD:
                            if (b)
                            {
                                ((DVD)d).Insert();
                            }
                            else
                            {
                                ((DVD)d).Reject();
                            }
                            break;
                    }
                }
            }
        }
        public bool PrintInfo(string text, string device)
        {
            bool res = false;
            foreach (var pd in printDevice)
            {
                if (pd?.GetName()== device)
                {
                    pd.Print(text);
                    res = true;
                }
            }
            return res;
        }
        public string ReadInfo(string device)
        {
            throw new NotImplementedException();
        }
        public void ShowDisk()
        {
            int counter=0;
            foreach (var d in disks)
            {
                Console.WriteLine($"{++counter} {d?.GetName()}");
            }
        }
        public void ShowPrintDevice()
        {
            int counter = 0;
            foreach (var d in printDevice)
            {
                Console.WriteLine($"{++counter} {d?.GetName()}");
            }
        }
        public bool WriteInfo(string text, string showDevice)
        {
            throw new NotImplementedException();
        }
        public Comp(int d, int pd)
        {
            countDisk = d;
            countPrintDevice = pd;
            disks=new Disk[countDisk];
            printDevice=new IPrintInformation[countPrintDevice];
        }
    }
}
