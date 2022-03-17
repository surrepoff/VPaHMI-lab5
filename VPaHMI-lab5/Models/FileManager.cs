using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaHMI_lab5.Models
{
    public class FileManager
    {
        public void Write(string data, string path)
        {
            using StreamWriter sw = File.CreateText(path);
            sw.Write(data);
        }
        public string Read(string path)
        {
            using StreamReader sr = File.OpenText(path);
            return sr.ReadToEnd();
        }
    }
}