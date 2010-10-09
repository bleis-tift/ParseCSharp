using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseCSharp
{
    public class FailureParser<T>
    {
        private string p;

        public FailureParser(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public ParseResult<T, Elem> Apply<Elem>(Reader<Elem> input)
        {
            return Failure._(p, input).Build<T>();
        }
    }
}
