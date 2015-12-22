using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DecoratorPattern
{
    public abstract class Reader
    {
        internal string s;

        public Reader()
        {
            s = "Not Known String";
        }

        public abstract string Read();
    }

    public class StringReader : Reader
    {
        public StringReader(string input)
        {
            this.s = input;
        }

        public override string Read()
        {
            return s;
        }
    }

    public class FileReader : Reader
    {
        FileInfo fileInfo;

        public FileReader(FileInfo fInfo)
        {
            this.fileInfo = fInfo;
        }

        public override string Read()
        {
            StreamReader reader = new StreamReader(fileInfo.FullName);
            return reader.ReadToEnd();
        }
    }
}
