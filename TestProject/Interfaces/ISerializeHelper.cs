﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Interfaces
{
    public interface ISerializeHelper 
    {
        void SerializeToJson<T>(T obj, string path)where T:class;
    }
}
