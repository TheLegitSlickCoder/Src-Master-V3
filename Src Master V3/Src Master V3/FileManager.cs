using System;
using System.IO;

namespace Src_Master_V3
{
    class FileManager
    {
        //Get Directories:
        public string[] getDirs(string path)
        {
            try
            {
                return Directory.GetDirectories(path);
            }
            catch
            {
                return null;
            }
        }

        //Get Files:
        public string[] getFiles(string path)
        {
            try
            {
                return Directory.GetFiles(path);
            }
            catch
            {
                return null;
            }
        }

        //Create File:
        public bool createFile(string path)
        {
            try
            {
                var f = File.Create(path);
                f.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Create Directory:
        public bool createDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}