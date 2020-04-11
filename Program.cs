using System;
using System.IO;

namespace FileSystemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.CreateDirectory(); // running multiple times will overwrite any preexisting instance, since it's an empty dir
            Console.Read(); // forces the console to stay open
        }

        public void CreateDirectory()
        {
            var dirName = "TestFolder";

            Directory.CreateDirectory(dirName);
        }
    }
}
