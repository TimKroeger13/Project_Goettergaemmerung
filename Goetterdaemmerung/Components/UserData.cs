using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung.Components
{
    public interface IUserData
    {
        string? ExportPath { get; set; }
        string? ImportPath { get; set; }
        PrintType Printer { get; set; }
        SaveFormat CurrentFormat { get; set; }
        int RebalenceNumber { get; set; }
    }

    public class UserData : IUserData
    {
        public string? ImportPath { get; set; }
        public string? ExportPath { get; set; }
        public PrintType Printer { get; set; } = PrintType.Print1;
        public SaveFormat CurrentFormat { get; set; } = SaveFormat.normal;
        public int RebalenceNumber { get; set; } = 1;
    }
}
