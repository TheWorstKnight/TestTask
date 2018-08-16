using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model;

namespace TestProject.Interfaces
{
    public interface IDirectoryInfoService
    {
        Folder GetDirectoryInfo(string directoryName); 
    }
}
