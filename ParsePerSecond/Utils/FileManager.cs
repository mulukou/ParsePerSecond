using System;
using System.IO;

namespace ParsePerSecond.Utils
{
    public class FileManager
    {
        private StreamWriter sw;

        public void Init(string fileName)
        {
            using FileStream fs = File.Create(fileName);
            using var sr = new StreamWriter(fs);
            this.sw = sr;
        }

        public void Write(string message)
        {
            if (this.sw == null)
                return;

            this.sw.WriteLine(message);
        }
    }
}