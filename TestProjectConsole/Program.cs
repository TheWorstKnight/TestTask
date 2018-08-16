using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Interfaces;
using TestProject.Model;
using TestProject.Service;

namespace TestProjectConsole
{
    class Program
    {
        private readonly static IDirectoryInfoService infoService = new DirectoryInfoService();
        private readonly static ISerializeHelper serializeHelper = new SerializeHelper();
        static void Main(string[] args)
        {
            string consoleResult;
            Folder f = null;
            while (true)
            {
                Console.WriteLine("Write the path to examine or \"Exit\" word to leave");
                consoleResult = Console.ReadLine();
                if (consoleResult == "Exit")
                    return;
                try
                {
                    f = infoService.GetDirectoryInfo(consoleResult);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("The entered path doesn't exist");
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine("The entered path doesn't exist");
                    continue;
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("The file in current directory is missing");
                    continue;
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine("Some files or folders couldn't be accessed in mentioned directory");
                    continue;
                }
                Console.WriteLine("Enter the result file destination");
                consoleResult = Console.ReadLine();
                if (consoleResult == "Exit")
                    return;
                try
                {
                    serializeHelper.SerializeToJson<Folder>(f, consoleResult);
                    Console.WriteLine("The file has been created. You can access it through following path: ");
                    Console.WriteLine($"{consoleResult}");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("The entered path doesn't exist");
                    continue;
                }
            }
        }
    }
}
