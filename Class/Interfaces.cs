using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    interface IRemoveableDisk
    {
        bool HasDisk { get; }
        void Insert();
        void Reject();
    }
    interface IDisk
    {
        string Read();
        void Write(string text);
    }
    interface IPrintInformation
    {
        string GetName();
        void Print(string str);
    }
}
