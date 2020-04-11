using System;
using System.IO;

namespace FileSystemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.CreateDirectory(); 
            Console.Read(); // forces the console to stay open
            app.CopySaveData();
            app.DeleteTmp();
        }

        public string[] folders =
        {
            // dont start with a \ because that means "the root of a dir", and we dont know where root exists
            @"Workspace\", // paths as strings, use @ before string, will convert the characters to unicode, dont have to escape
            @"Workspace\Archive\",
            @"Workspace\Tmp\",
            @"Workspace\Tmp\SaveData\"
        };

        public enum FolderNames
        {
            Workspace,
            Archive,
            Tmp,
            SaveData
        }

        public void CreateDirectory()
        {
            var total = folders.Length; // get total number of dirs we want to create

            for(var i = 0; i < total; i++)
            {
                var dirName = GetFolderByName((FolderNames)i) ;
                if (Directory.Exists(dirName))
                {
                    Console.WriteLine("Dir '" + dirName + "' exists");
                }
                else
                {
                    Directory.CreateDirectory(dirName);
                    Console.WriteLine("Create Dir '" + dirName + "'");
                }
            }
        }

        public void DeleteTmp()
        {
            var tmpDir = GetFolderByName(FolderNames.Tmp);
            
            if (Directory.Exists(tmpDir))
            {
                Directory.Delete(tmpDir, true);
            }
            
        }

        public void CopySaveData()
        {
            var saveDataDir = GetFolderByName(FolderNames.SaveData);

            if(Directory.Exists(saveDataDir))
            {
                var destDirName = GetFolderByName(FolderNames.Archive) + "SaveData_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                Directory.Move(saveDataDir, destDirName);
            }
        }

        public string GetFolderByName(FolderNames name)
        {
            return folders[(int) name];
        }
    }
}
