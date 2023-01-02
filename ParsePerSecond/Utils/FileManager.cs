using System;
using System.IO;
using Dalamud.Logging;

namespace ParsePerSecond.Utils
{
    public class FileManager
    {
        private StreamWriter destinationStream;

        public FileManager(string filePath)
        {
            // FileStream destinationStream = File.Open("parse.log", FileMode.OpenOrCreate);

            StreamWriter destinationStream = new StreamWriter(filePath);
            this.destinationStream = destinationStream;
        }

        public void Write(string message)
        {
            this.destinationStream.WriteLine(message);
        }

        public void Dispose()
        {
            this.destinationStream.Dispose();
        }
    }
}