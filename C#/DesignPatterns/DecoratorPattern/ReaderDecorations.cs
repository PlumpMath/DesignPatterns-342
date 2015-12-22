using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DecoratorPattern
{
    public abstract class ReaderDecorator : Reader
    {
        internal Reader reader;
    }

    public class LowercaseReader : ReaderDecorator
    {
        public LowercaseReader(Reader stringReader)
        {
            this.reader = stringReader;
        }

        public override string Read()
        {
            return reader.Read().ToLower();
        }
    }

    public class UppercaseReader : ReaderDecorator
    {
        public UppercaseReader(Reader Reader)
        {
            this.reader = Reader;
        }

        public override string Read()
        {
            return reader.Read().ToUpper();
        }
    }
}
