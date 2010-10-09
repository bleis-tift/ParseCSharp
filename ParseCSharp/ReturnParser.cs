using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseCSharp
{
    public class ReturnParser<T>
    {
        private T p;

        public ReturnParser(T p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }
        public ParseResult<T, Elem> Apply<Elem>(Reader<Elem> input)
        {
            return Success._(p, input);
        }
    }
}
