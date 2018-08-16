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
    public class Folder
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public List<Folder> Subfolders { get; set; }

        [DataMember]
        public List<DirectoryFile> Files { get; set; }
    }
}
