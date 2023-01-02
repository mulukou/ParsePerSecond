using System;
using System.IO;

namespace ParsePerSecond.Utils
{
    public static class File
    {
        private StreamWriter sw;

        public static Init(string fileName)
        {
            using FileStream fs = File.Create(fileName);
            using var sr = new StreamWriter(fs);
            this.sw = sr;
        }

        public Write(string message)
        {
            if (this.sw == null)
                return;

            this.sw.WriteLine(message);
        }
    }
}