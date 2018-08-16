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
        /// <summary>
        /// Converts obj to json format and writes it in file in path destination
        /// </summary>
        /// <typeparam name="T">Any reference type</typeparam>
        /// <param name="obj">Object to serialize</param>
        /// <param name="path">Json file destination path</param>
        public void SerializeToJson<T>(T obj, string path) where T : class
        {
            string dir = path;
            
            if (new DirectoryInfo(dir).Exists)
            {
                dir += "\\result.json";
                string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
                File.WriteAllText(dir, json);
            }
            else throw new ArgumentException();
        }
    }
}
