using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Interfaces;
using TestProject.Model;

namespace TestProject.Service
{
    public class DirectoryInfoService : IDirectoryInfoService
    {
        public Folder GetDirectoryInfo(string directoryName)
        {
            string dir = directoryName;
            if (!Directory.Exists(dir))
            {
                throw new ArgumentException();
            }
            Folder f = new Folder();
            DriveInfo[] drives = DriveInfo.GetDrives();
            bool dirIsDrive = false;
            foreach (DriveInfo drive in drives)
            {
                if (drive.Name == dir)
                {
                    f.Name = drive.Name;
                    dirIsDrive = true;
                }
            }

            if (!dirIsDrive)
            {
                f.Name = new DirectoryInfo(dir).Name;
                f.Date = new DirectoryInfo(dir).CreationTime;
            }

            f.Files = new List<DirectoryFile>();

            try
            {
                foreach (var file in new DirectoryInfo(dir).GetFiles() ?? Enumerable.Empty<FileInfo>())
                {
                    f.Files.Add(new DirectoryFile
                    {
                        Name = file.Name,
                        Path = file.FullName,
                        Size = file.Length
                    });
                }
            }
            catch (UnauthorizedAccessException e)
            {

                throw e;
            }

            catch (DirectoryNotFoundException e)
            {
                throw e;
            }

            catch (FileNotFoundException e)
            {
                throw e;
            }

            f.Subfolders = new List<Folder>();

            try
            {
                foreach (var sub in new DirectoryInfo(dir).GetDirectories() ?? Enumerable.Empty<DirectoryInfo>())
                {
                    f.Subfolders.Add(GetDirectoryInfo(sub.FullName));
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw e;
            }
            catch (DirectoryNotFoundException e)
            {
                throw e;
            }

            return f;
        }

    }
}
