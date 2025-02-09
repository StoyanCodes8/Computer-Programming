using System;
using System.IO;

namespace P07.FolderSize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string absolutePath = @"C:\Users\Stoya\Desktop";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.GetRelativePath(basePath, absolutePath);
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string output = Path.Combine(projectRoot, "output.txt");
            // Калкулирай Папките
            string[] directories = Directory.GetDirectories(absolutePath);
            long totalSize = 0; // КАКВО Е lONG?
            foreach (string dir in directories)
            {
                //Калкулирай файловете в папките
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                { 
                 FileInfo fileInfo = new FileInfo(file);
                 totalSize += fileInfo.Length; 
                }
            }
            var result = totalSize / 1024;
            File.WriteAllText(output, result.ToString());
        }
    }
}
