using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Goettergaemmerung.Components
{
    public interface IUserData
    {
        string ExportPath { get; set; }
        string ImportPath { get; set; }
    }

    public class UserData : IUserData
    {
        public string ImportPath { get; set; }
        public string ExportPath { get; set; }
    }
}
