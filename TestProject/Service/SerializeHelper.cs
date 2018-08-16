using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Interfaces;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;

namespace TestProject.Service
{
    public class SerializeHelper : ISerializeHelper
    {
        public void SerializeToJson<T>(T collection, string path)
        {
            string dir = path;
            
            if (new DirectoryInfo(dir).Exists)
            {
                dir += "\\result.json";
                string json = JsonConvert.SerializeObject(collection, Formatting.Indented);
                File.WriteAllText(dir, json);
            }
            else throw new ArgumentException();
        }
    }
}
