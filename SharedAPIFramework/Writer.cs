using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SharedAPIFramework
{
    public class Writer : IDisposable
    {

        private StreamWriter _writer;
        public string Path { get; private set; }
        //public Writer(StreamWriter writer, string path)
        //{
        //    _writer = writer;
        //    Path = path;
        //}

        public Writer( string path)
        {
            
            Path = path;
        }


        public void WriteLine(string line)

        {
            _writer.WriteLine(DateTime.Now.ToString() + " " + line + "<br>");
        }

        public void Write(string line)

        {
            _writer.WriteLine(line);
        }

        public void Dispose()

        {
            _writer.Dispose();
        }
    }
}
