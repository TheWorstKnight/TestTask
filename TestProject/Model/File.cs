using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace TestProject.Model
{
    [DataContract]
    public class DirectoryFile
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public long Size { get; set; }

        [DataMember]
        public string Path { get; set; }
    }
}
